using Caiji.Library.Service;
using Caiji.Service.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caiji.Library.Model;
using Caiji.Model;
using Caiji.Service;

namespace Caiji
{
    public partial class Form1 : Form
    {
        private readonly IHospitalService _hospitalService;
        private readonly IDepartmentService _departmentService;
        private readonly IClientService _clientService;
        private string currentAction;//当前动作
        private bool loaded;//浏览器加载完毕
        private string currentUrl;//当前浏览器地址
        private int insCount = 0;
        private int clientCount = 0;
        /// <summary>
        /// 医院采集入口，{0}=全国 {1}=1
        /// </summary>
        private string hospitalStartUrl = "https://www.guahao.com/hospital/area/default/2/{0}/all/不限/all/all/all/default/0/true/region_sort/p{1}";//医院入口
        public Form1()
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            _hospitalService = new HospitalService(new MyDbContext());
            _departmentService = new DepartmentService(new MyDbContext());
            _clientService = new ClientService(new MyDbContext());
            InitializeComponent();
            Init();
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        public void Init()
        {
            LoadHospital();
        }
        /// <summary>
        /// 加载医院入口
        /// </summary>
        public void LoadHospital()
        {
            //1、采集医院入口页面总数,假设max最大999
            var url = string.Format(hospitalStartUrl, "上海", 999);//初始化上海医院入口
            currentAction = "hospital";
            webBrowser1.Navigate(url);
            webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
        }
        /// <summary>
        /// 浏览器加载完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var wb = (WebBrowser)sender;
            //处理医院list
            if (wb.Document != null && wb.Document.Url == e.Url)
            {
                loaded = true;
                currentUrl = wb.Document.Url.ToString();
            }
        }



        private void btn_start_Click(object sender, EventArgs e)
        {
            if (loaded)
            {
                var t = new Thread(Start);
                t.Start();
            }
            else
            {
                MessageBox.Show("急个屁啊，浏览器还没准备好");
            }

        }

        public void Start()
        {
            var condition = new[]
            {
                new Condition
                {
                    Name = "page",
                    Start = "<span class=\"current\">",
                    End = "</span>",
                }
            };
            int x;
            //最大页码数
            var maxPage =
                Helper.ProcessorValue(condition, webBrowser1.Url.ToString(), "utf-8", "", string.Empty)
                    .SelectMany(n => n.Value)
                    .Select(n => n.Value).Where(n => Int32.TryParse(n, out x)).Select(Int32.Parse).ToArray();

            //拼接Url数组
            for (var i = 1; i <= maxPage.FirstOrDefault(); i++)
            {
                var url = string.Format(hospitalStartUrl, "上海", i);
                //获取医院详细URL
                var hospitalDetailUrls = Helper.ProcessorValue(new[]
                    {
                        new Condition
                        {
                            Name = "detailUrl",
                            Start = "<a class=\"a\" href=\"",
                            End = "\" target=",
                        }
                    }, url, "utf-8", "g-hospital-item J_hospitalItem")
                    .Select(n => n.Value.Where(p => p.ConditionName == "detailUrl").Select(p => p.Value)
                        .FirstOrDefault()).ToArray();
                //获取医院数据
                foreach (var hospitalDetailUrl in hospitalDetailUrls)
                {
                    GetHospitalData(hospitalDetailUrl);
                }

            }
        }

        /// <summary>
        /// 获取医院信息
        /// </summary>
        /// <param name="hospitalDetailUrl"></param>
        public void GetHospitalData(string hospitalDetailUrl)
        {
            //医院信息过滤
            var cdhc = new[]
            {
                new Condition
                {
                    Name = "level",
                    Start = "<h3 style=\"display: inline-block;\">                <span class=\"h3\">                ",
                    End = "                </span>",
                },
                new Condition
                {
                    Name = "site",
                    Start = "<b>官网：</b>                <span>&nbsp;",
                    End = "</span>",
                },
                new Condition
                {
                    Name = "code",
                    Start = "'hosp-id': \"",
                    End = "\"    }",
                },
                new Condition
                {
                    Name = "lat",
                    Start = "lat : \"",
                    End = "\","
                },
                new Condition
                {
                    Name = "lng",
                    Start = "lng : \"",
                    End = "\","
                },
                new Condition
                {
                    Name = "name",
                    Start = "name : \"",
                    End = "\","
                },
                new Condition
                {
                    Name = "tel",
                    Start = "tel : \"",
                    End = "\","
                },
                new Condition
                {
                    Name = "address",
                    Start = "addr : \"",
                    End = "\","
                },
            };
            var html = Helper.GetHtmlSourceCodeFromUrl(hospitalDetailUrl, "utf-8").Replace("\r\n", "");

            var hospitalDetailResult = Helper.ProcessorValue(cdhc, string.Empty, "utf-8", string.Empty, html).Select(n => new Hospital
            {
                Id = Guid.NewGuid(),
                Name = n.Value.Where(p => p.ConditionName == "name").Select(p => p.Value).FirstOrDefault(),
                Code = n.Value.Where(p => p.ConditionName == "code").Select(p => p.Value).FirstOrDefault(),
                Site = n.Value.Where(p => p.ConditionName == "site").Select(p => p.Value).FirstOrDefault(),
                Level = n.Value.Where(p => p.ConditionName == "level").Select(p => p.Value).FirstOrDefault(),
                TelNumber = n.Value.Where(p => p.ConditionName == "tel").Select(p => p.Value).FirstOrDefault(),
                Address = n.Value.Where(p => p.ConditionName == "address").Select(p => p.Value).FirstOrDefault(),
                Lng = n.Value.Where(p => p.ConditionName == "lng").Select(p => p.Value).FirstOrDefault(),
                Lat = n.Value.Where(p => p.ConditionName == "lat").Select(p => p.Value).FirstOrDefault(),
                Url = hospitalDetailUrl,
                Departments = new List<Department>()
            }).ToArray();
            //医院数据插入数据库
            for (int i = 0; i < hospitalDetailResult.Length; i++)
            {
                insCount++;
                lbl_inscount.Text = insCount.ToString();
                lbl_insname.Text = hospitalDetailResult[i].Name;
                _hospitalService.Insert(hospitalDetailResult[i]);
            }

            //获取医院下的科室信息
            var loop = "monitor=\"hospital,hospital_order";
            var depConditions = new[]
            {
                new Condition
                {
                    Name = "code",
                    Start = "monitor-div-id=\"",
                    End = "\"",
                },
                new Condition
                {
                    Name = "name",
                    Start = "?isStd=\"                                               >                                            ",
                    End = "                                            </a>",
                },
                new Condition
                {
                    Name = "name2",
                    Start = "isStd=\"                                               title=\"",
                    End = "\">",
                }
            };
            var depDetailResult = Helper.ProcessorValue(depConditions, string.Empty, "utf-8", loop, html).Select(n => new Department
            {
                Id = Guid.NewGuid(),
                Name = n.Value.Where(p => p.ConditionName.Contains("name")).Select(p => p.Value).OrderByDescending(p => p.Length).FirstOrDefault(),
                Code = n.Value.Where(p => p.ConditionName == "code").Select(p => p.Value).FirstOrDefault(),
                HospitalId = hospitalDetailResult.Select(p => p.Id).FirstOrDefault(),
                Url = hospitalDetailUrl,
                Clients = new List<Client>()
            }).ToArray();
            //部门数据插入数据库

            for (int i = 0; i < depDetailResult.Length; i++)
            {
                lbl_depcount.Text = (i + 1).ToString();
                lbl_depname.Text = depDetailResult[i].Name;
                _departmentService.Insert(depDetailResult[i]);
                GetClientData(depDetailResult[i]);
            }

        }

        /// <summary>
        /// 获取医生信息
        /// </summary>
        /// <param name="dep"></param>
        public void GetClientData(Department dep)
        {
            //最大化页码数，获取maxpage
            var maxpageurl = string.Format("https://www.guahao.com/department/shiftcase/{0}?pageNo=1", dep.Code);
            var condition = new[]
            {
                new Condition
                {
                    Name = "page",
                    Start = "if (no > ",
                    End = ") {",
                }
            };
            int x;
            //最大页码数
            var maxPage =
                Helper.ProcessorValue(condition, maxpageurl, "utf-8", "", string.Empty)
                    .SelectMany(n => n.Value)
                    .Select(n => n.Value).Where(n => Int32.TryParse(n, out x)).Select(Int32.Parse).ToArray();
            //拼接Url数组
            for (var i = 1; i <= maxPage.FirstOrDefault(); i++)
            {
                var url = string.Format("https://www.guahao.com/department/shiftcase/{0}?pageNo={1}", dep.Code, i);
                var loop = "g-doctor-item2 g-clear to-margin";
                var depConditions = new[]
                {
                    new Condition
                    {
                        Name = "code",
                        Start = "https://www.guahao.com/expert/",
                        End = "?hospitalId=",
                    },
                    new Condition
                    {
                        Name = "name",
                        Start = "(this,'DOCN_1')\">                            <em>",
                        End = "</em>",
                    },
                    new Condition
                    {
                        Name = "title",
                        Start = "&nbsp;&nbsp;                    ",
                        End = "                    </dt>",
                    },
                    new Condition
                    {
                        Name = "describe",
                        Start = "<strong>擅长：</strong>",
                        End = "            </div>",
                    }
                };

                //获取医生信息
                var clientDetailResult = Helper.ProcessorValue(depConditions, url, "utf-8", loop).Select(n => new Client
                {
                    Id = Guid.NewGuid(),
                    Name = n.Value.Where(p => p.ConditionName.Contains("name")).Select(p => p.Value).OrderByDescending(p => p.Length).FirstOrDefault(),
                    Code = n.Value.Where(p => p.ConditionName == "code").Select(p => p.Value).FirstOrDefault(),
                    Title = n.Value.Where(p => p.ConditionName == "title").Select(p => p.Value).FirstOrDefault(),
                    Describe = n.Value.Where(p => p.ConditionName == "describe").Select(p => p.Value.Trim()).FirstOrDefault(),
                    Url = url,
                    DepartmentId = dep.Id
                }).Where(n => n.Title != null).ToArray();
                //医生数据插入数据库

                for (int j = 0; j < clientDetailResult.Length; j++)
                {
                    clientCount++;
                    lbl_clientcount.Text = (j + 1).ToString();
                    _clientService.Insert(clientDetailResult[j]);
                    lbl_clientcounttotal.Text = clientCount.ToString();
                }

            }

        }
    }
}
