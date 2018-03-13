using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Caiji.Library.Model.Interfaces;

namespace Caiji.Library.Model
{
    public class Client :IDtStamped
    {
        [Key]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 头衔
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string Post { get; set; }
        public Guid DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }
        public string Url { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public string Flags { get; set; }

        public DateTime? UpdateTime { get; set; }

        public DateTime CreatedTime { get; set; }

        public bool IsDeleted { get; set; }
    }
}
