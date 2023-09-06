using AutoMapper;
using InovasyonCourse.API.Model;
using InovasyonCourse.BussinessLayer.Abstract;
using InovasyonCourse.BussinessLayer.Model.VMs;
using InovasyonCourse.CoreLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InovasyonCourse.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[AllowAnonymous]
	public class LoginController : ControllerBase
	{

		private readonly SignInManager<AppNetUser> _signInManager;
		private readonly UserManager<AppNetUser> _userManager;
		private readonly IConfiguration _configuration;
		private readonly IServiceProvider _serviceProvider;

		public LoginController(UserManager<AppNetUser> userManager, SignInManager<AppNetUser> signInManager, IConfiguration configuration, IServiceProvider serviceProvider)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_configuration = configuration;
			_serviceProvider = serviceProvider;
		}
		//[HttpPost]
		//public IActionResult Login(LoginVM model)
		//{
		//	var users = _adminService.GetUsers();
		//	var isThereUser = users.SingleOrDefault(x => Convert.ToInt64(x.Id) == model.UserId && x.Password == model.Password);
		//	if (isThereUser != null)
		//	{
		//		var createToken = new CreateToken(_configuration, _serviceProvider); // CreateToken örneği oluşturuluyor
		//		var token = createToken.TokenCreateAdmin(); // Token üretimi
		//		return Ok(new { token });
		//	}
		//	return BadRequest("There is no such user. Try again");//Böyle bir kullanıcı yok. Tekrar deneyiniz
		//}
		[HttpPost]
		public async Task<IActionResult> Login(LoginVM model)
		{
			var user = await _userManager.FindByEmailAsync(model.Email);
			if (user != null)
			{
				var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, true); // Şifre doğrulama işlemi
				if (result.Succeeded)
				{
					var createToken = new CreateToken(_configuration, _serviceProvider); // CreateToken örneği oluşturuluyor
					var token = createToken.GenerateJwtToken(user); // Token üretimi
					return Ok(new { token });
				}
			}
			return Unauthorized();
		}

	}
}
