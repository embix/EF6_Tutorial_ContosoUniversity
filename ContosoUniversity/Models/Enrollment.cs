using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public Int32 EnrollmentId { get; set; }
        public Int32 CourseId { get; set; }
        public Int32 StudentId { get; set; }

        [DisplayFormat(NullDisplayText = "No grade")]
        public Nullable<Grade> Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}