using InovasyonCourse.BussinessLayer.Model.DTOs;
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
		Courses GetByCodeCourse(string code);
		Users GetByCodeStudent(long code);
		void Maching(Users student, StudentMachingCourseDTO addStudentDto);
	}
}
