﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace the_website_test.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DB_A50C7A_FEEEntities : DbContext
    {
        public DB_A50C7A_FEEEntities()
            : base("name=DB_A50C7A_FEEEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<LecturesTable> LecturesTable { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<StaffMembers> StaffMembers { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<StudentSubject> StudentSubject { get; set; }
        public virtual DbSet<SubjectDepend> SubjectDepend { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
    
        [DbFunction("DB_A50C7A_FEEEntities", "GetRequiredSubjects")]
        public virtual IQueryable<GetRequiredSubjects_Result> GetRequiredSubjects(Nullable<int> subjectID)
        {
            var subjectIDParameter = subjectID.HasValue ?
                new ObjectParameter("subjectID", subjectID) :
                new ObjectParameter("subjectID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<GetRequiredSubjects_Result>("[DB_A50C7A_FEEEntities].[GetRequiredSubjects](@subjectID)", subjectIDParameter);
        }
    }
}
