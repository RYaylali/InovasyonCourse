using InovasyonCourse.BussinessLayer.Abstract;
using InovasyonCourse.BussinessLayer.Model.DTOs;
using InovasyonCourse.CoreLayer.Enums;
using InovasyonCourse.CoreLayer;
using InovasyonCourse.DataAccessLayer.Abstract;
using InovasyonCourse.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InovasyonCourse.BussinessLayer.Concrete
{
	public class UserCourseManager : IUserCourseService
	{
		private readonly IUserCourseDal _userCourseDal;
		private readonly IStudentService _studentService;

		public UserCourseManager(IUserCourseDal userCourseDal, IStudentService studentService)
		{
			_userCourseDal = userCourseDal;
			_studentService = studentService;
		}
		public List<UserCourse> MyCourse(MyCourseDto model)
		{
			if (model!=null)
			{
				var myCourse = _userCourseDal.GetAllUserList(model.UserId);
				return myCourse;
			}

			return null;
		}
	}
}
