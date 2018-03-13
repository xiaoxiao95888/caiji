using System;

namespace Caiji.Library.Model.Interfaces
{
    public interface IDtStamped
    {
        DateTime? UpdateTime { get; set; }
        DateTime CreatedTime { get; set; }
        bool IsDeleted { get; set; }
    }
}
