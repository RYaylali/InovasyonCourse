using AutoMapper;
using InovasyonCourse.BussinessLayer.Abstract;
using InovasyonCourse.BussinessLayer.Model.VMs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InovasyonCourse.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly IAdminService _adminService;

		 public LoginController(IAdminService adminService)
		{
			_adminService = adminService;
		}
		static long userLogiId;
		[HttpPost]
		public IActionResult Login(LoginVM model)
		{
			var users = _adminService.GetUsers();
			var isThereUser=users.SingleOrDefault(x=>x.UserId == model.UserId && x.Password==model.Password);
			if (isThereUser!=null)
			{
				userLogiId = isThereUser.UserId;
				return Ok(isThereUser);
			}
			return BadRequest("There is no such user. Try again");//Böyle bir kullanıcı yok. Tekrar deneyiniz
		}

	}
}
