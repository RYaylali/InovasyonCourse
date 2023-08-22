using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InovasyonCourse.CoreLayer
{
	public class Courses
	{
        [Key]//Id olduğunu belirtmek için
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        //Navigasyon prop Bir kişi aynı dersi bir kere seçer. Çünkü bir derste bir kişiden iki tane olamaz
        public long?  UserId { get; set; }
        public virtual Users? Users { get; set; }
    }
}
