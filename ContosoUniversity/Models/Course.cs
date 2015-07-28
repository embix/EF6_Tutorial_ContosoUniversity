using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public Int32 CourseId { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public String Title { get; set; }

        [Range(0, 5)]
        public Int32 Credits { get; set; }

        public Int32 DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; } 
    }
}