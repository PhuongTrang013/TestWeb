using System;
using System.ComponentModel.DataAnnotations;

namespace PPCRental.Models
{
    public class PropertyMetadata
    {
        [Key]
        public int ID { get; set; }

        [StringLength(100)]
        [Display(Name = "PropertyName")]
        public string PropertyName { get; set; }

        [StringLength(500)]
        [Display(Name = "PropertyName")]
        public string Content { get; set; }

        public Nullable<int> Street_ID { get; set; }

        public Nullable<int> Ward_ID { get; set; }

        public Nullable<int> District_ID { get; set; }

        [Range(0d, double.MaxValue)]
        public Nullable<int> Price { get; set; }

    }

    public class EnrollmentMetadata
    {
        [Range(0d, double.MaxValue)]
        public Nullable<decimal> Price;
    }
}
