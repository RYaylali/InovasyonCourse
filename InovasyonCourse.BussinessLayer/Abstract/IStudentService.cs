using InovasyonCourse.CoreLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InovasyonCourse.BussinessLayer.Abstract
{
	public interface IStudentService 
	{
		List<Courses> GetCourses();
		List<Users> GetStudents();
		Users GetByCodeStudent(long code);
	}
}
