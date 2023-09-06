using InovasyonCourse.CoreLayer.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InovasyonCourse.CoreLayer
{
	public class AppNetUser : IdentityUser<Guid>
	{
        public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime BirthDate { get; set; }

		//Navigasyon prop birden fazla DERSİ KULLANICI seçebilir
		public virtual ICollection<Courses>? Courses { get; set; }
		public AppNetUser()
		{
			Courses = new HashSet<Courses>();//nesneleri benzersiz olması için hashset kullandım aynı ilandan açmaması için eğer birden fazla ekleme yapılırsa hashset bir kopya tutar
		}
	}
}
