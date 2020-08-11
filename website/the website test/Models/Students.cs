//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Students
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Students()
        {
            this.StudentSubject = new HashSet<StudentSubject>();
        }
    
        public int ID { get; set; }
        public string SSN { get; set; }
        public Nullable<int> AcademicNumber { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string FullAddress { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public Nullable<int> DeptID { get; set; }
        public string Image_path { get; set; }
    
        public virtual Departments Departments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentSubject> StudentSubject { get; set; }
    }
}
