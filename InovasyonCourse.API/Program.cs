using InovasyonCourse.BussinessLayer.Extensions;
using InovasyonCourse.DataAccessLayer.Concrete;
using InovasyonCourse.DataAccessLayer.Extensions;

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
									   //builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
									   //policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));//atýlan bütün baþlýk methot ve originleri kabul eder.
									   //policy.WithOrigins("http://localhost:3000", "https://localhost:3000/").AllowAnyHeader().AllowAnyMethod()//bütün header ve methodlara cevap verir.
									   //bu yerden gelen istekleri al 
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
			builder.Services.AddDbContext<Context>();
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
			app.UseCors();
			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}