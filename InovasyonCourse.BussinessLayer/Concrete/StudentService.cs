using AutoMapper;
using InovasyonCourse.BussinessLayer.Abstract;
using InovasyonCourse.BussinessLayer.Model.DTOs;
using InovasyonCourse.CoreLayer;
using InovasyonCourse.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InovasyonCourse.BussinessLayer.Concrete
{
	public class StudentService : IStudentService
	{
		private readonly ICourseDal _courseDal;
		private readonly IUserDal _userDal;

		public StudentService(ICourseDal courseDal, IUserDal userDal)
		{
			_courseDal = courseDal;
			_userDal = userDal;
		}

		public AppNetUser GetByCodeStudent(long code)
		{
			return _userDal.GetByCodeStudentID(code);
		}

		public Courses GetByCodeCourse(string code)
		{
			var courses = _courseDal.GetByCodeCourseID(code);
			return courses;
		}
		public List<Courses> GetCourses()
		{
			var courses = _courseDal.GetList();
			return courses;
		}
		public List<AppNetUser> GetStudents()
		{
			var users = _userDal.GetList();
			return users;
		}
		//public void Maching(Users student, StudentMachingCourseDTO studentMachinCourse)
		//{
		//	var course = _courseDal.GetByCodeCourseID(studentMachinCourse.CourseId);
		//	var userCourse = new UserCourse()
		//	{
		//		CourseId = course.CourseId,
		//		UserId = student.Id
		//	};
		//	student.UserCourses.Add(userCourse);
		//	_userCourseDal.Insert(userCourse);
		//}
	}
}
