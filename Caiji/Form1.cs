using Caiji.Library.Service;
using Caiji.Service.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
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
        private string currentAction; //当前动作
        private bool loaded; //浏览器加载完毕
        private string currentUrl; //当前浏览器地址
        private int insCount = 0;
        private int clientCount = 0;

        /// <summary>
        /// 医院采集入口，{0}=全国 {1}=1
        /// </summary>
        private string hospitalStartUrl =
                "https://www.guahao.com/hospital/area/default/all/{0}/all/不限/all/all/all/default/0/true/region_sort/p{1}"
            ; //医院入口

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
            var url = string.Format(hospitalStartUrl, "全国", 999); //初始化全国医院入口
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
                if (string.IsNullOrEmpty(tbx.Text))
                {
                    MessageBox.Show("请填入URL");
                }
                else
                {
                    var t = new Thread(Start);
                    t.Start();
                }

            }
            else
            {
                MessageBox.Show("急个屁啊，浏览器还没准备好");
            }

        }

        public void Start()
        {
            //首页入口
            var rootUrls = new List<string>();
            for (int i = 0; i < tbx.Lines.Length; i++)
            {
                if (!string.IsNullOrEmpty(tbx.Lines[i]))
                {
                    rootUrls.Add(tbx.Lines[i]);
                }

            }
             ;
            /*var rootUrls = new[]
            {
                "https://www.guahao.com/hospital/area/default/1/北京/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/2/上海/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/29/广东/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/22/江苏/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/24/浙江/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/9/陕西/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/11/甘肃/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/21/山东/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/8/山西/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/19/湖北/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/30/湖南/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/3/天津/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/15/四川/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/25/江西/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/23/安徽/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/20/河南/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/16/河北/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/12/青海/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/5/辽宁/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/18/贵州/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/4/重庆/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/7/黑龙江/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/17/云南/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/31/广西/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/10/宁夏/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/14/西藏/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/33/内蒙古/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/32/海南/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/6/吉林/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/13/新疆/all/不限/all/all/all/default/0/true/region_sort/p{0}",
                "https://www.guahao.com/hospital/area/default/27/福建/all/不限/all/all/all/default/0/true/region_sort/p{0}"
            };*/
            foreach (var item in rootUrls)
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
                    Helper.ProcessorValue(condition, string.Format(item, 999), "utf-8", "", string.Empty)
                        .SelectMany(n => n.Value)
                        .Select(n => n.Value).Where(n => Int32.TryParse(n, out x)).Select(Int32.Parse).ToArray().FirstOrDefault();
                maxPage = maxPage == 0 ? 1 : maxPage;

                //拼接Url数组
                for (var i = 1; i <= maxPage; i++)
                {
                    var url = string.Format(item, i);
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
            }).FirstOrDefault();
            if (hospitalDetailResult != null)
            {
                var divisionLoop = "www.guahao.com/hospital/areahospitals";
                var divisionConditions = new[]
                {
                    new Condition
                    {
                        Name = "division",
                        Start = "return _smartlog(this,'NAV')\">",
                        End = "</a>",
                    }
                };
                hospitalDetailResult.Division = string.Join(",",
                    Helper.ProcessorValue(divisionConditions, string.Empty, "utf-8", divisionLoop, html).Select(n =>
                        n.Value.Where(p => p.ConditionName == "division").Select(p => p.Value).FirstOrDefault()
                    ));
                //医院数据插入数据库
                insCount++;
                lbl_inscount.Text = insCount.ToString();
                lbl_insname.Text = hospitalDetailResult.Name;
                _hospitalService.Insert(hospitalDetailResult);
                var loop = "monitor=\"hospital,hospital_order";
                var depConditions = new[]
                {
                    new Condition
                    {
                        Name = "code",
                        Start = "monitor-div-id=\"",
                        End = "\"",
                    }
                };
                var depCodes = Helper.ProcessorValue(depConditions, string.Empty, "utf-8", loop, html).Select(n => n.Value
                    .Where(p => p.ConditionName == "code").Select(p => p.Value).FirstOrDefault()).ToArray();
                GetDepartmentData(hospitalDetailResult, depCodes);
            }
        }

        public void GetDepartmentData(Hospital hospital, string[] depCodes)
        {
            //获取科室信息
            var depConditions = new[]
            {
                new Condition
                {
                    Name = "name",
                    Start = "<div class=\"info\"><div class=\"detail word-break\"><h1><strong>",
                    End = "</strong>",
                },
            };
            var i = 0;
            foreach (var code in depCodes)
            {
                i++;
                var depUrl = string.Format("https://www.guahao.com/department/{0}?isStd=", code);
                var depDetailResult = Helper.ProcessorValue(depConditions, depUrl, "utf-8", string.Empty).Select(n => new Department
                {
                    Id = Guid.NewGuid(),
                    Name = n.Value.Where(p => p.ConditionName.Contains("name")).Select(p => p.Value).OrderByDescending(p => p.Length).FirstOrDefault(),
                    Code = code,
                    HospitalId = hospital.Id,
                    Url = depUrl,
                    Clients = new List<Client>()
                }).FirstOrDefault();
                if (depDetailResult != null)
                {
                    lbl_depcount.Text = i.ToString();
                    lbl_depname.Text = depDetailResult.Name;
                    _departmentService.Insert(depDetailResult);
                    GetClientData(depDetailResult, hospital);
                }
            }
        }

        /// <summary>
        /// 获取医生信息
        /// </summary>
        /// <param name="dep"></param>
        public void GetClientData(Department dep, Hospital hospital)
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
                    .Select(n => n.Value).Where(n => Int32.TryParse(n, out x)).Select(Int32.Parse).ToArray().FirstOrDefault();
            maxPage = maxPage == 0 ? 1 : maxPage;

            //拼接Url数组
            for (var i = 1; i <= maxPage; i++)
            {
                var docListUrl = string.Format("https://www.guahao.com/department/shiftcase/{0}?pageNo={1}", dep.Code, i);
                //获取医生详细页面url
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
                        Name = "title",
                        Start = "&nbsp;&nbsp;                    ",
                        End = "                    </dt>",
                    },
                };
                //医生编码
                var clientCodes = Helper.ProcessorValue(depConditions, docListUrl, "utf-8", loop).Select(n => new
                {
                    Code = n.Value.Where(p => p.ConditionName == "code").Select(p => p.Value).FirstOrDefault(),
                    Title = n.Value.Where(p => p.ConditionName == "title").Select(p => p.Value).FirstOrDefault()
                }).Where(n => n.Title != null).ToArray();
                var j = 0;
                foreach (var code in clientCodes)
                {
                    j++;
                    var detailUrl = string.Format("https://www.guahao.com/expert/{0}?hospDeptId={1}&hospitalId={2}",
                        code.Code, dep.Code, hospital.Code);
                    var clientConditions = new[]
                    {
                        new Condition
                        {
                            Name = "avatar",
                            Start = "<div class=\"summary\">                    <p>                        <img src=\"",
                            End = "\" alt=",
                        },
                        new Condition
                        {
                            Name = "name",
                            Start = "<strong class=\"J_ExpertName\">",
                            End = "</strong>",
                        },
                        new Condition
                        {
                            Name = "title",
                            Start = "</strong>                        <span> ",
                            End = "</span>",
                        },
                        new Condition
                        {
                            Name = "post",
                            Start = "                        <span>/</span>                        <span>",
                            End = "</span>",
                        },
                        new Condition
                        {
                            Name = "specialty",
                            Start = "<b>擅长：</b>                        <span>",
                            End = "</span>",
                        },
                        new Condition
                        {
                            Name = "describe",
                            Start = "<b>简介：</b>                        <span>",
                            End = "</span>",
                        },

                    };
                    var html = Helper.GetHtmlSourceCodeFromUrl(detailUrl, "utf-8");
                    //获取医生信息
                    var clientDetailResult = Helper.ProcessorValue(clientConditions, string.Empty, "utf-8", string.Empty, html).Select(n => new Client
                    {
                        Id = Guid.NewGuid(),
                        Name = n.Value.Where(p => p.ConditionName.Contains("name")).Select(p => p.Value).OrderByDescending(p => p.Length).FirstOrDefault(),
                        Code = code.Code,
                        Title = n.Value.Where(p => p.ConditionName == "title").Select(p => p.Value).FirstOrDefault(),
                        Describe = n.Value.Where(p => p.ConditionName == "describe").Select(p => p.Value.Trim()).FirstOrDefault(),
                        Specialty = n.Value.Where(p => p.ConditionName == "specialty").Select(p => p.Value.Trim()).FirstOrDefault(),
                        Post = n.Value.Where(p => p.ConditionName == "post").Select(p => p.Value.Trim()).FirstOrDefault(),
                        AvatarUrl = n.Value.Where(p => p.ConditionName == "avatar").Select(p => p.Value.Trim()).FirstOrDefault(),
                        Url = detailUrl,
                        DepartmentId = dep.Id
                    }).FirstOrDefault();
                    if (clientDetailResult != null)
                    {
                        var loopFlags = "<a class=\"gb2 gb2-orange disease-bt\"";
                        var flagsConditions = new[]
                        {
                            new Condition
                            {
                                Name = "flag",
                                Start = "hidefocus=\"true\" title=\"",
                                End = "\">",
                            }

                        };
                        var flag = Helper.ProcessorValue(flagsConditions, string.Empty, "utf-8", loopFlags, html)
                            .Select(n =>
                                n.Value.Where(p => p.ConditionName == "flag").Select(p => p.Value).FirstOrDefault()).ToArray();
                        if (flag.Any())
                        {
                            clientDetailResult.Flags = string.Join(",", flag);
                        }
                        clientDetailResult.Flags = string.Join(",", flag);
                        clientCount++;
                        lbl_clientcount.Text = j.ToString();
                        _clientService.Insert(clientDetailResult);
                        lbl_clientcounttotal.Text = clientCount.ToString();
                    }
                }

                //var detailUrl = 
                /* var loop = "g-doctor-item2 g-clear to-margin";
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
                 }*/

            }

        }
    }
}
