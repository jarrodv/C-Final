//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CTUCampus.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Parent
    {
        public Parent()
        {
            this.Students = new HashSet<Student>();
        }
    
        public int ParentID { get; set; }
        public string parentName { get; set; }
        public string parentSurname { get; set; }
        public string parentIDNumber { get; set; }
        public int parentAge { get; set; }
        public string parentContactNumber { get; set; }
    
        public virtual ICollection<Student> Students { get; set; }
    }
}