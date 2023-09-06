using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InovasyonCourse.CoreLayer
{
	public class Courses
	{
        public Guid ID { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        //Navigasyon prop 
        public Guid? UserId { get; set; }
        public AppNetUser? Users { get; set; }
    }
}
