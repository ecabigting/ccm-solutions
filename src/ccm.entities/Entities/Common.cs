using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ccm.entities.Entities
{
    public class Common
    {
        [Required]
        public Guid Id { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset UpdatedDateTime { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        [Required]
        public bool IsEnabled {get;set;}
        [Required]
        public Guid IsEnabledBy { get; set; }
        public virtual void UpdateAuditFields(Guid id,bool enabled)
        {
            this.UpdatedBy = id;
            this.UpdatedDateTime = DateTimeOffset.Now;
            this.IsEnabled = enabled;
            this.IsEnabledBy = id;
        }

        public virtual void SetAuditFields(Guid id,bool enabled)
        {
            this.CreatedBy = id;
            this.CreatedDateTime = DateTimeOffset.Now;
            this.IsEnabled = enabled;
            this.IsEnabledBy = id;
            this.UpdatedBy = id;
            this.UpdatedDateTime = DateTimeOffset.Now;
        }
    }
}