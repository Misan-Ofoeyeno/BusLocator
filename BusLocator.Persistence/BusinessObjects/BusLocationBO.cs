using BusLocator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusLocator.Persistence.BusinessObjects
{
    [Table("BusLocation")]
    public class BusLocationBO : BusLocation
    {
        public BusLocationBO()
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

        public override Guid RouteId
        {
            get
            {
                return base.RouteId;
            }
            set
            {
                base.RouteId = value;
            }
        }

        [ForeignKey("BusId")]
        public virtual BusBO Bus { get; set; }

        [ForeignKey("RouteId")]
        public virtual RouteBO Route { get; set; }
    }
}
