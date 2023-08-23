using InovasyonCourse.CoreLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InovasyonCourse.CoreLayer
{
	public class Users
	{
		[Key]//Id olduğunu belirtmek için
		public long UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime BirthDate { get; set; }
        public string Password { get; set; }
		public Role Role { get; set; }

		//Navigasyon prop birden fazla DERSİ KULLANICI seçebilir
        public virtual ICollection<UserCourse> UserCourses { get; set; }
        public Users()
        {
            UserCourses= new HashSet<UserCourse>();//nesneleri benzersiz olması için hashset kullandım aynı ilandan açmaması için eğer birden fazla ekleme yapılırsa hashset bir kopya tutar
		}
    }
}
