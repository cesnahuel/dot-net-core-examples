using System;
using System.ComponentModel.DataAnnotations;


namespace ContosoUniversity.Models.SchoolViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        [Display(Name = "Enrollment Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? EnrollmentDate { get; set; }
        [Display(Name = "Students")]
        public int StudentCount { get; set; }
    }
}
