using InovasyonCourse.BussinessLayer.Extensions;
using InovasyonCourse.CoreLayer;
using InovasyonCourse.DataAccessLayer.Concrete;
using InovasyonCourse.DataAccessLayer.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace InovasyonCourse.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services
				.AddEFCoreServices(builder.Configuration)
				.AddBusinessServices();//ioc işlemlerini yapar
			var connectionString = builder.Configuration.GetConnectionString("ConnStr");
			builder.Services.AddDbContext<Context>(options =>
				options.UseSqlServer(connectionString));


			builder.Services.AddCors(options =>
			{
				options.AddDefaultPolicy(policy =>
				{
					policy.AllowAnyOrigin()
						  .AllowAnyMethod()
						  .AllowAnyHeader();
				});
			});
			// Add services to the container.
			//builder.Services.AddDbContext<Context>();
			builder.Services.AddIdentity<AppNetUser, AppNetRole>(opt =>
			{
				opt.Password.RequireDigit = false;              //�ifremiz say� i�ermesine gerek yok
				opt.Password.RequiredLength = 1;               //gerekli uzunluk 1 e �ektik gibi d�zenlemeler yap�labilir.
				opt.Password.RequireLowercase = false;
				opt.Password.RequireUppercase = false;
				opt.Password.RequireNonAlphanumeric = false;
				opt.SignIn.RequireConfirmedEmail = false;

				//Default olarak false gelir. SignInResult "IsNotAllowed" �zelli�i dir . Mail onaylamas�.
				opt.Lockout.MaxFailedAccessAttempts = 10;       //4 hatal� denemeden sonra hesab� kitle
				opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30); //Hesab� 5 dakika boyunca kitle dedik. 
				opt.User.AllowedUserNameCharacters = "abcçdefgğhıijklmnoöpqrsştuüvwxyzABCÇDEFGHIJKLMNOÖPQRSŞTUÜVWXYZ0123456789-._@+";
			}).AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();
			//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
			//{
			//	opt.RequireHttpsMetadata = false;
			//	opt.TokenValidationParameters = new TokenValidationParameters()
			//	{
			//		ValidIssuer = "http://localhost",//kimin tarafından karşılık bulacağı
			//		ValidAudience = "http://localhost",//kim tarafından dinleneceğini gösterir
			//		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aspnetcoreapiapi")),//kim hangi veriyi sağlarsa giriş yapacağı değeri gösterir
			//		ValidateIssuerSigningKey = true,//signingkey çözümünü sağlar.Yukarıdaki aspnetcoreapiapi codunu çözer
			//		ValidateLifetime = true,//tokenin geçerlilik süresi token 5 dk geçerli örneğin
			//		ClockSkew = TimeSpan.Zero
			//	};
			//});
			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			var app = builder.Build();
			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseStaticFiles();
			app.UseCors();
			app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseAuthorization();
			app.MapControllers();
			app.Run();
		}
	}
}