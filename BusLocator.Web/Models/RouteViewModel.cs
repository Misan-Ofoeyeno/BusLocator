using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusLocator.Web.Models
{
    public class RouteViewModel
    {
        public Guid RouteId { get; set; }

        [Required]
        public string RouteName { get; set; }

        [Required]
        public string ShortName { get; set; }
    }
}