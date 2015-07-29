using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.ViewModels
{
    public class AssignedCourseData
    {
        public Int32 CourseId { get; set; }
        public String Title { get; set; }
        public Boolean Assigned { get; set; }
    } 
}