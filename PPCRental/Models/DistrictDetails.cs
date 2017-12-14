using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PPCRental.Models
{
    public class DistrictDetails
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        [Required]
        public string DistrictName { get; set; }

        [Required]
        public Nullable<bool> Status { get; set; }

        // ???
        public List<Details> Details { get; set; }

        public List<StreetDetails> StreetDetails { get; set; }

        public List<WardDetails> WardDetails { get; set; }
    }
}