using AutoMapper;
using InovasyonCourse.BussinessLayer.Model.DTOs;
using InovasyonCourse.CoreLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InovasyonCourse.BussinessLayer.AutoMapper
{
	public class Mapping: Profile
	{
        public Mapping()
        {
			CreateMap<Users, AddStudentDTO>().ReverseMap();
			CreateMap<Users, UpdateStudentDTO>().ReverseMap();
		}
    }
}
