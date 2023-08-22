using InovasyonCourse.DataAccessLayer.Abstract;
using InovasyonCourse.DataAccessLayer.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InovasyonCourse.DataAccessLayer.Extensions
{
	public static class DependencyInjectionEFCore
	{
		public static IServiceCollection AddEFCoreServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<ICourseDal, EFCourseDal>();
			services.AddScoped<IUserDal, EFUserDal>();
			return services;
		}
	}
}
