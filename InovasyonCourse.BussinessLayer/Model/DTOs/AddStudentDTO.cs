﻿using InovasyonCourse.CoreLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InovasyonCourse.BussinessLayer.Model.DTOs
{
	public class AddStudentDTO
	{
		public Guid ID  => Guid.NewGuid();
        public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public DateTime BirthDate { get; set; }
		public string Password { get; set; }
	}
}
