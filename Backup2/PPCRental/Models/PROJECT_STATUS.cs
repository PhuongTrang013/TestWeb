//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PPCRental.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PROJECT_STATUS
    {
        public PROJECT_STATUS()
        {
            this.PROPERTies = new HashSet<PROPERTY>();
        }
    
        public int ID { get; set; }
        public string Status_Name { get; set; }
        public Nullable<bool> Status { get; set; }
    
        public virtual ICollection<PROPERTY> PROPERTies { get; set; }
    }
}
