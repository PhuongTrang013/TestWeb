using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPCRental.Models
{
    public class WardDetails
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        [Required]
        public string WardName { get; set; }

        [Required]
        public Nullable<bool> Status { get; set; }

        //Tới bảng District
        public virtual DistrictDetails DistrictDetails { get; set; }

        [Key]
        [Required]
        [ForeignKey(nameof(Models.DistrictDetails))]
        [Column(Order = 0)]
        public int District_ID { get; set; }

        [StringLength(50)]
        [Required]
        public int DistrictName { get; set; }
        public List<Details> Details { get; set; }
    }
}