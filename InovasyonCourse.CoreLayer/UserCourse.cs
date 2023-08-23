using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InovasyonCourse.CoreLayer
{
	public class UserCourse
	{
		public long? UserId { get; set; }
		public virtual Users? Users { get; set; }
		public string? CourseId { get; set; }
		public virtual Courses? Courses { get; set; }
	}
}
