﻿using InovasyonCourse.DataAccessLayer.Abstract;
using InovasyonCourse.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InovasyonCourse.DataAccessLayer.Repositories
{
	public class GenericRepository<T> : IGenericDal<T> where T : class
	{
		private readonly Context _context;

		public GenericRepository(Context context)
		{
			_context = context;
		}

		public void Delete(T entity)
		{
			_context.Remove(entity);
			_context.SaveChanges();
		}

		public T GetByID(long id)
		{
			return _context.Set<T>().Find(id);
		}

		public List<T> GetList()
		{
			return _context.Set<T>().ToList();
		}

		public void Insert(T entity)
		{
			_context.Add(entity);
			_context.SaveChanges();
		}

		public void Update(T entity)
		{
			_context.Update(entity);
			_context.SaveChanges();
		}
	}
}