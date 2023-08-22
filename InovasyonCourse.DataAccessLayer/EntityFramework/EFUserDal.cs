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
	public class EFUserDal :GenericRepository<Users>,IUserDal
	{
        public EFUserDal(Context context):base(context)
        {
            
        }
    }
}
