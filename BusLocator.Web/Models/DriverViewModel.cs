﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusLocator.Web.Models
{
    public class DriverViewModel
    {
        public string UserId { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string EmployeeId { get; set; }
    }
}