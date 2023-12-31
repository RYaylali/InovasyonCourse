﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InovasyonCourse.DataAccessLayer.Abstract
{
	public interface IGenericDal<T> where T : class
	{
		void Insert(T entity);
		void Update(T entity);
		void Delete(T entity);
		List<T> GetList();
		T GetByCodeStudentID(long id);
		T GetByCodeCourseID(string id);
	}
}
