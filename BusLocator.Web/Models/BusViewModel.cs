using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusLocator.Web.Models
{
    public class BusViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string BusId { get; set; }

        public bool HasAccessibility { get; set; }
    }
}