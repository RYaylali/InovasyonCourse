using AutoMapper;
using InovasyonCourse.BussinessLayer.Abstract;
using InovasyonCourse.BussinessLayer.Model.DTOs;
using InovasyonCourse.CoreLayer.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InovasyonCourse.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminController : ControllerBase
	{
		private readonly IAdminService _adminService;
		private readonly IStudentService _studentService;
		private readonly IMapper _mapper;

		public AdminController(IAdminService adminService, IMapper mapper, IStudentService studentervice)
		{
			_adminService = adminService;
			_mapper = mapper;
			_studentService = studentervice;
		}
		[HttpGet("StudentList")]
		public IActionResult GetAllStudents()
		{
			var companyList = _adminService.GetStudents();
			if (companyList is not null)
			{
				return Ok(companyList);
			}
			return BadRequest("Not list");
		}
		[HttpGet("CoursesList")]
		public IActionResult GetAllCourses()
		{
			var companyList = _adminService.GetCourses();
			if (companyList is not null)
			{
				return Ok(companyList);
			}
			return BadRequest("Not list");
		}
		[HttpPost("CreateStudent")]
		public IActionResult CreateStudent(AddStudentDTO model)
		{
			if (model is not null)
			{
				_adminService.CreateStudent(model);
				return Ok("Create Student");
			}
			return BadRequest("Not create");
		}
		[HttpPut("UpdateStudent")]
		public IActionResult UpdateStudent(UpdateStudentDTO model)
			{
			var student = _studentService.GetByCodeStudent(model.UserId);
			if (student is not null)
			{
				var updateStudent=_mapper.Map<UpdateStudentDTO>(model);
				_adminService.UpdateStudent(updateStudent);
				return Ok("Update Student");
			}
			return BadRequest("Not update");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteStudent(long id)
		{
			try
			{
				_adminService.DeleteStudent(id);
				return Ok("Delete Student");
			}
			catch (Exception)
			{

				throw;
			}	
			
		}
	}
}
