using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ContosoUniversity.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        [Column("FirstName")]
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return $"{LastName}, {FirstMidName}"; }
        }

        [Display(Name = "Course Assignments")]
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
        [Display(Name = "Office Location")]
        public OfficeAssignment OfficeAssignment { get; set; }
    }
}
