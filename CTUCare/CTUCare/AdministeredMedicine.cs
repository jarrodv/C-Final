//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CTUCare
{
    using System;
    using System.Collections.Generic;
    
    public partial class AdministeredMedicine
    {
        public int ID { get; set; }
        public Nullable<int> PatientID { get; set; }
        public Nullable<int> MedicineID { get; set; }
        public Nullable<int> DateAdministeredID { get; set; }
    
        public virtual EntryDate EntryDate { get; set; }
        public virtual Medicine Medicine { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
