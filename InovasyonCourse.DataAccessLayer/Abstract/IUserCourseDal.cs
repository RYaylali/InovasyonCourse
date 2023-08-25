using InovasyonCourse.CoreLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InovasyonCourse.DataAccessLayer.Abstract
{
	public interface IUserCourseDal:IGenericDal<UserCourse>
	{
		List<UserCourse> GetAllUserList(long id);
	}
}
