using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Caiji.Library.Model.Interfaces;

namespace Caiji.Library.Model
{
    public class Hospital: IDtStamped
    {
        [Key]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Level { get; set; }
        public string TelNumber { get; set; }
        public string Lng { get; set; }
        public string Lat { get; set; }
        /// <summary>
        /// 行政区域
        /// </summary>
        public string Division { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        /// <summary>
        /// 医院网站
        /// </summary>
        public string Site { get; set; }
        public string Url { get; set; }
        public DateTime? UpdateTime { get; set; }

        public DateTime CreatedTime { get; set; }

        public bool IsDeleted { get; set; }
    }
}
