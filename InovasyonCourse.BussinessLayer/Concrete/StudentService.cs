using InovasyonCourse.BussinessLayer.Abstract;
using InovasyonCourse.CoreLayer;
using InovasyonCourse.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InovasyonCourse.BussinessLayer.Concrete
{
	public class StudentService:IStudentService
	{
		private readonly ICourseDal _courseDal;
		private readonly IUserDal _userDal;

		public StudentService(ICourseDal courseDal, IUserDal userDal)
		{
			_courseDal = courseDal;
			_userDal = userDal;
		}

		public Users GetByCodeStudent(long code)
		{
			return _userDal.GetByID(code);
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
	}
}
