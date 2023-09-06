using AutoMapper;
using InovasyonCourse.BussinessLayer.Model.DTOs;
using InovasyonCourse.BussinessLayer.Model.VMs;
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
			CreateMap<AppNetUser, AddStudentDTO>().ReverseMap();
			CreateMap<AppNetUser, UpdateStudentDTO>().ReverseMap();
			CreateMap<AppNetUser, LoginVM>().ReverseMap();
			CreateMap<Courses, StudentMachingCourseDTO>().ReverseMap();
			CreateMap<StudentMachingCourseDTO, UpdateStudentDTO>().ReverseMap();
		}
    }
}
