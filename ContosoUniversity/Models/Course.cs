using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int32 CourseId { get; set; }
        public String Title { get; set; }
        public Int32 Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}