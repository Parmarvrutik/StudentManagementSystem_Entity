//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentManagementSystem_Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Student
    {
        public int Stud_ID { get; set; }
        public string Stud_name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Dept_id { get; set; }
        public int Course_id { get; set; }
    
        public virtual Tbl_Course Tbl_Course { get; set; }
        public virtual Tbl_Dept Tbl_Dept { get; set; }
    }
}
