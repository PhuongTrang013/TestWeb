using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using PPCRental.Models;

namespace PPCRental.Models
{
    public class UserMetadata
    {

        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}