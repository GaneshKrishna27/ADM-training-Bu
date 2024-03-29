//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;
namespace MiniProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            this.Courses = new HashSet<Cours>();
        }

        [Key]
        public int stdId { get; set; }
        [Required(ErrorMessage = "Student Name is required")]
        [Display(Name = "Student Name")]
        public string stdName { get; set; }
        [Required(ErrorMessage = "Branch is required")]
        [Display(Name = "Branch")]
        public string stdBranch { get; set; }
        [Required(ErrorMessage = "City is required")]
        [Display(Name = "City")]
        public string stdCity { get; set; }
        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "You must provide a phone number"), MaxLength(10)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[7-9]{1}[0-9]{9}$", ErrorMessage = "Not a valid phone number")]
        public string stdPhn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cours> Courses { get; set; }
    }
}
