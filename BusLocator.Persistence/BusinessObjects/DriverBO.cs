using BusLocator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusLocator.Persistence.BusinessObjects
{
    [Table("Driver")]
    public class DriverBO : Driver
    {
        public DriverBO(string userId)
        {
            UserId = userId;
        }

        [Key]
        public override string UserId
        {
            get
            {
                return base.UserId;
            }

            set
            {
                base.UserId = value;
            }
        }

        [ForeignKey("UserId")]
        public virtual UserBO User { get; set; }
    }
}
