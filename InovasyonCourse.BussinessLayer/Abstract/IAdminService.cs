using InovasyonCourse.BussinessLayer.Model.DTOs;
using InovasyonCourse.CoreLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InovasyonCourse.BussinessLayer.Abstract
{
	public interface IAdminService
	{
		List<AppNetUser> GetStudents();
		Task<string> CreateStudent(AddStudentDTO model);
		bool UpdateStudent(UpdateStudentDTO model);
		bool DeleteStudent(long id);
		List<Courses> GetCourses();
		List<AppNetUser> GetUsers();
	}
}
