﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StudEntities : DbContext
    {
        public StudEntities()
            : base("name=StudEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tbl_Course> Tbl_Course { get; set; }
        public virtual DbSet<Tbl_Dept> Tbl_Dept { get; set; }
        public virtual DbSet<Tbl_Student> Tbl_Student { get; set; }
    }
}
