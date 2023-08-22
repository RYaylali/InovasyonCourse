using AutoMapper;
using InovasyonCourse.BussinessLayer.Abstract;
using InovasyonCourse.BussinessLayer.Model.DTOs;
using InovasyonCourse.CoreLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InovasyonCourse.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly IAdminService _adminService;
		private readonly IStudentService _studentService;
		private readonly IMapper _mapper;

		public StudentController(IAdminService adminService, IMapper mapper, IStudentService studentervice)
		{
			_adminService = adminService;
			_mapper = mapper;
			_studentService = studentervice;
		}
		[HttpGet("StudentList")]
		public IActionResult GetAllStudents()
		{
			var companyList =  _studentService.GetStudents();
			if (companyList is not null)
			{
				return Ok(companyList);
			}
			return BadRequest("Not list");
		}
		[HttpGet("CoursesList")]
		public IActionResult GetAllCourses()
		{
			var companyList = _studentService.GetCourses();
			if (companyList is not null)
			{
				return Ok(companyList);
			}
			return BadRequest("Not list");
		}
		[HttpPost]
		public IActionResult CorseMaching(long studentCode,string courseId)
		{
			var student = _studentService.GetByCodeStudent(studentCode);
			if (student != null && student.Courses.Any(x => x.CourseId != courseId))
			{
				Courses user = new Courses()
				{
					UserId = studentCode,
				};
				var studentCourse = _mapper.Map<UpdateStudentDTO>(user);
				_adminService.UpdateStudent(studentCourse);
				return Ok(student);
			}
			return BadRequest("Not student");
		}
	}
}
