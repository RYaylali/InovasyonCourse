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
		private readonly IStudentService _studentService;
		private readonly IMapper _mapper;

		public StudentController(IMapper mapper, IStudentService studentervice)
		{
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
		public IActionResult CorseMaching(StudentMachingCourseDTO model)
		{
			var student = _studentService.GetByCodeStudent(model.UserId);
			var course = _studentService.GetByCodeCourse(model.CourseId);
			if (student != null && student.Courses.All(x => x.CourseCode != model.CourseId))
			{
				//_studentService.Maching(student,model);
				return Ok(student);
			}
			return BadRequest("Student already enrolled in the course");
		}
	}
}
