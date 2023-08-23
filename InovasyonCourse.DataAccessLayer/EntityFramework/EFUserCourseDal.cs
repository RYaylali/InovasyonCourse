using InovasyonCourse.CoreLayer;
using InovasyonCourse.DataAccessLayer.Abstract;
using InovasyonCourse.DataAccessLayer.Concrete;
using InovasyonCourse.DataAccessLayer.Repositories;
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
	}
}
