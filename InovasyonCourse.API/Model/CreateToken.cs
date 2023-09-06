using InovasyonCourse.CoreLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InovasyonCourse.API.Model
{
	public class CreateToken
	{
		private readonly IConfiguration _configuration;
		private readonly IServiceProvider _serviceProvider;

		public CreateToken(IConfiguration configuration, IServiceProvider serviceProvider)
		{
			_configuration = configuration;
			_serviceProvider = serviceProvider;
		}

		public string GenerateJwtToken(AppNetUser user)
		{
			using (var scope = _serviceProvider.CreateScope())
			{
				var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppNetUser>>();

				var jwtSettings = _configuration.GetSection("JwtSettings");
				var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
				var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
				var claims = new List<Claim>
				{
					new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
					new Claim(JwtRegisteredClaimNames.Email, user.Email),
			     // Diğer talepleri ekleyebilirsiniz.
				};

				var token = new JwtSecurityToken(
				issuer: jwtSettings["Jwt:Issuer"], // Veren (Issuer)
				audience: jwtSettings["Jwt:Audience"], // İzleyici (Audience)
				claims: claims,
				expires: DateTime.UtcNow.AddHours(2), // Token süresi, UTC olarak ayarlandı
				signingCredentials: creds
				);
				var tokenHandler = new JwtSecurityTokenHandler();
				return tokenHandler.WriteToken(token);

			}
		}
		public string TokenCreateAdmin()
		{
			var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapi");
			SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
			SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			List<Claim> claims = new List<Claim>()
			{
				new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
				//new Claim(ClaimTypes.Role,"Admin"),
				//new Claim(ClaimTypes.Role,"Visitor")
			};

			JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost", notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(30), signingCredentials: credentials, claims: claims);

			JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
			return handler.WriteToken(jwtSecurityToken);
		}
	}
}
