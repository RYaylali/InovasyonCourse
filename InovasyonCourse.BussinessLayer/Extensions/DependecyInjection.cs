using InovasyonCourse.BussinessLayer.Abstract;
using InovasyonCourse.BussinessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InovasyonCourse.BussinessLayer.Extensions
{
	public static class DependecyInjection
	{
		public static IServiceCollection AddBusinessServices(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddTransient<IAdminService, AdminService>();
			services.AddTransient<IStudentService, StudentService>();
			//Buraya servislerin dönüşümü yazılacak
			return services;
		}
	}
}
