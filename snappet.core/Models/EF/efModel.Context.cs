﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace snappet.core.Models.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SnappetEntities : DbContext
    {
        public SnappetEntities()
            : base("name=SnappetEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Domain> Domains { get; set; }
        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<LearningObjective> LearningObjectives { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectDomainLink> SubjectDomainLinks { get; set; }
        public virtual DbSet<SubmittedAnswer> SubmittedAnswers { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}