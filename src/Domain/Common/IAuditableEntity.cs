using System;

namespace Domain.Common
{
    public interface IAuditableEntity
    {
        DateTime CreatedDate { get; set; }

        DateTime? UpdatedDate { get; set; }

        string CreatedBy { get; set; }

        string UpdatedBy { get; set; }
    }
}
