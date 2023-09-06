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
	public class EFUserDal :GenericRepository<AppNetUser>,IUserDal
	{
		private readonly Context _context;
		public EFUserDal(Context context):base(context)
        {
			_context = context;   
        }
		public List<AppNetUser> GetUsersList()
		{
			return _context.Users.ToList();
		}
	}
}
