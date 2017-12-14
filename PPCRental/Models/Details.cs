using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using PPCRental.Models;

namespace PPCRental.Models
{
    public class Details
    {
        //Content Column Table
        [Key]
        public int ID { get; set; }

        [StringLength(100)]
        [Required]
        public string PropertyName { get; set; }

        [StringLength(500)]
        [Required]
        public string Content { get; set; }

        [Key]
        [Required]
        public Nullable<int> Street_ID { get; set; }

        [Key]
        [Required]
        public Nullable<int> Ward_ID { get; set; }

        [Key]
        [Required]
        public Nullable<int> District_ID { get; set; }

        [Required]
        [Range(0d, double.MaxValue)]
        public Nullable<int> Price { get; set; }


        //???
        public List<Property_Feature_Details> Property_Feature_Details { get; set; }
    }
}