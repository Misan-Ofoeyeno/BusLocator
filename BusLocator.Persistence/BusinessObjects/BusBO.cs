using BusLocator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusLocator.Persistence.BusinessObjects
{
    [Table("Bus")]
    public class BusBO : Bus
    {
        public BusBO()
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

        [ForeignKey("RouteId")]
        public virtual RouteBO Route { get; set; }
    }
}
