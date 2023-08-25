using InovasyonCourse.CoreLayer;
using InovasyonCourse.DataAccessLayer.Abstract;
using InovasyonCourse.DataAccessLayer.Concrete;
using InovasyonCourse.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InovasyonCourse.DataAccessLayer.EntityFramework
{
	public class EFUserCourseDal : GenericRepository<UserCourse>, IUserCourseDal
	{
		public EFUserCourseDal(Context context) : base(context)
		{
		}

		public List<UserCourse> GetAllUserList(long id)
		{
			var context =new Context();
			var courseUserList = context.UserCourses
				.Include(x => x.Courses) // İlgili kurs bilgilerini dahil ediyoruz
				.Where(x => x.UserId == id)
				.ToList();
			return courseUserList;
		}
	}
}
