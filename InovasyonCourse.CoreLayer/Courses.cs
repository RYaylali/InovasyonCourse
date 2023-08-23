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
        [Key]//Id olduğunu belirtmek için
        public string CourseId { get; set; }
        public string CourseName { get; set; }
		//Navigasyon prop 
		public virtual ICollection<UserCourse> UserCourses { get; set; }
		public Courses()
		{
			UserCourses = new HashSet<UserCourse>();//nesneleri benzersiz olması için hashset kullandım aynı ilandan açmaması için eğer birden fazla ekleme yapılırsa hashset bir kopya tutar
		}
	}
}
