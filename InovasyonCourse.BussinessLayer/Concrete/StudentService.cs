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
		private readonly IUserCourseDal _userCourseDal;

		public StudentService(ICourseDal courseDal, IUserDal userDal, IUserCourseDal userCourseDal)
		{
			_courseDal = courseDal;
			_userDal = userDal;
			_userCourseDal = userCourseDal;
		}

		public Users GetByCodeStudent(long code)
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
		public List<Users> GetStudents()
		{
			var users = _userDal.GetList();
			return users;
		}
		public void Maching(Users student, StudentMachingCourseDTO studentMachinCourse)
		{
			var course = _courseDal.GetByCodeCourseID(studentMachinCourse.CourseId);
			var userCourse = new UserCourse()
			{
				CourseId = course.CourseId,
				UserId = student.UserId
			};
			student.UserCourses.Add(userCourse);
			_userCourseDal.Insert(userCourse);			
		}
	}
}
