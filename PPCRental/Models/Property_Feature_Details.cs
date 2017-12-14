using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PPCRental.Models
{
    public class Property_Feature_Details
    {
        //Details nè
        public virtual Details Details { get; set; }

        [Key]
        [Required]
        [ForeignKey(nameof(Models.Details))]
        [Column(Order = 0)]
        public int Property_ID { get; set; }


        //Tính năng nè
        public virtual FEATURE FEATURE { get; set; }

        [Key]
        [Required]
        [ForeignKey(nameof(Models.FEATURE))]
        [Column(Order = 1)]
        public int Feature_ID { get; set; }

        [StringLength(50)]
        [Required]
        public int FeatureName { get; set; }

        [StringLength(50)]
        [Required]
        public int Icon { get; set; }
    }
}