using BusLocator.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLocator.Domain.Entity
{
    public class Audit
    {
        public void Initialize()
        {
            CreatedDate = this.ModifiedDate = DateTime.UtcNow;
            RecordStateType = RecordStateType.Active;
        }

        public Audit()
        {
            Initialize();
        }

        public Audit(string userId)
        {
            CreatedBy = ModifiedBy = userId;
            Initialize();
        }

        public Audit ModifyState(string userId)
        {
            Audit self = this;
            self.ModifiedBy = userId;
            self.ModifiedDate = DateTime.UtcNow;
            return self;
        }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public RecordStateType RecordStateType { get; set; } 
    }
}