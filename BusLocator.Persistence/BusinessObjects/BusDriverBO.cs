using BusLocator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusLocator.Persistence.BusinessObjects
{
    [Table("BusDriver")]
    public class BusDriverBO : BusDriver
    {
        public BusDriverBO()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public override Guid Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                base.Id = value;
            }
        }

        public override Guid BusId
        {
            get
            {
                return base.BusId;
            }
            set
            {
                base.BusId = value;
            }
        }

        public override string DriverUserId
        {
            get
            {
                return base.DriverUserId;
            }
            set
            {
                base.DriverUserId = value;
            }
        }

        [ForeignKey("BusId")]
        public virtual BusBO Bus { get; set; }

        [ForeignKey("DriverUserId")]
        public virtual DriverBO Driver { get; set; }
    }
}
