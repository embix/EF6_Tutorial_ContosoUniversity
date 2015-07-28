using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class OfficeAssignment
    {
        [Key]
        [ForeignKey("Instructor")]
        public Int32 InstructorId { get; set; }

        [StringLength(50)]
        [Display(Name = "Office Location")]
        public String Location { get; set; }

        public virtual Instructor Instructor { get; set; }
    }
}