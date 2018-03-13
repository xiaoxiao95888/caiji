using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Caiji.Library.Model.Interfaces;

namespace Caiji.Library.Model
{
    public class Department : IDtStamped
    {
        [Key]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid HospitalId { get; set; }
        [ForeignKey("HospitalId")]
        public virtual Hospital Hospital { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public string Url { get; set; }
        public DateTime? UpdateTime { get; set; }

        public DateTime CreatedTime { get; set; }

        public bool IsDeleted { get; set; }
    }
}
