using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.ViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public Nullable<DateTime> EnrollmentDate { get; set; }

        public Int32 StudentCount { get; set; }
    }
}