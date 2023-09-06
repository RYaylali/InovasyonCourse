using AutoMapper;
using InovasyonCourse.BussinessLayer.Abstract;
using InovasyonCourse.BussinessLayer.Model.DTOs;
using InovasyonCourse.CoreLayer;
using InovasyonCourse.CoreLayer.Enums;
using InovasyonCourse.DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Identity;
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
		private readonly UserManager<AppNetUser> _userManager;

		public AdminService(ICourseDal courseDal, IUserDal userDal, IMapper mapper, UserManager<AppNetUser> userManager)
		{
			_courseDal = courseDal;
			_userDal = userDal;
			_mapper = mapper;
			_userManager = userManager;
		}
		public async Task<string> CreateStudent(AddStudentDTO model)
		{
			if (model is not null)
			{
				var user = _mapper.Map<AddStudentDTO,AppNetUser>(model);
				var result = await _userManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{
					var passwordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
					user.PasswordHash = passwordHash;
					await _userManager.UpdateAsync(user);
					await _userManager.AddToRoleAsync(user, "Student");
					return "Create Student";
				}
			}
			return "Student creation failed";
		}


		public bool DeleteStudent(long id)
		{
			var user = _userDal.GetByCodeStudentID(id);
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
		public List<AppNetUser> GetUsers()
		{
			return _userDal.GetUsersList();
		}

		public List<AppNetUser> GetStudents()
		{
			List<AppNetUser> students = new List<AppNetUser>();
			var getUsers = _userDal.GetList();
			foreach (var student in getUsers)
			{
			
					students.Add(student);
				
			}
			return students;
		}

		public bool UpdateStudent(UpdateStudentDTO model)
		{
			var existingUser = _userDal.GetByCodeStudentID(model.UserId);
			if (existingUser != null)
			{
				existingUser.FirstName = model.FirstName;
				existingUser.LastName = model.LastName;
				existingUser.BirthDate = model.BirthDate;
				_userDal.Update(existingUser);
				return true;
			}

			return false;
		}
	}
}
