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
	public class AdminService : IAdminService
	{
		private readonly ICourseDal _courseDal;
		private readonly IUserDal _userDal;
		private readonly IMapper _mapper;

		public AdminService(ICourseDal courseDal, IUserDal userDal, IMapper mapper)
		{
			_courseDal = courseDal;
			_userDal = userDal;
			_mapper = mapper;
		}
		public string CreateStudent(AddStudentDTO model)
		{
			if (model is not null)
			{
				var create = _mapper.Map<Users>(model);
				_userDal.Insert(create);
				return "Create Student";
			}
			return "student creation failed";
		}

		public bool DeleteStudent(long id)
		{
			var user= _userDal.GetByID(id);
			if (user != null)
			{
				_userDal.Delete(user);
				return true;
			}
			return false;
		}

		public List<Courses> GetCourses()
		{
			return _courseDal.GetList();
		}

		public List<Users> GetStudents()
		{
			return _userDal.GetList();
		}

		public bool UpdateStudent(UpdateStudentDTO model)
		{
			if (model is not null)
			{
				var create = _mapper.Map<Users>(model);
				_userDal.Update(create);
				return true;
			}
			return false;
		}
	}
}
