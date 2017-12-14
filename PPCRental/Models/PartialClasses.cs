using System;
using System.ComponentModel.DataAnnotations;

namespace PPCRental.Models
{
    public class PartialClasses
    {
        [MetadataType(typeof(PropertyMetadata))]
        public partial class PROPERTY
        {

        }

        [MetadataType(typeof(EnrollmentMetadata))]
        public partial class Enrollment
        {

        }
    }
}