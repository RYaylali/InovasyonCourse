﻿using InovasyonCourse.BussinessLayer.Model.DTOs;
using InovasyonCourse.CoreLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InovasyonCourse.BussinessLayer.Abstract
{
	public interface IUserCourseService
	{
		List<UserCourse> MyCourse(MyCourseDto model);
	}
}
