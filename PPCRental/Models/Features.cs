using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PPCRental.Models
{
    public class Features
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        [Required]
        public string FeatureName { get; set; }

        [Required]
        public Nullable<bool> Status { get; set; }

        [StringLength(50)]
        [Required]
        public string Icon { get; set; }

        public List<Property_Feature_Details> Property_Feature_Details { get; set; }
    }
}