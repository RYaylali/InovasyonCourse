using InovasyonCourse.CoreLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InovasyonCourse.DataAccessLayer.Concrete
{
	public class Context : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-491CL38\\YAYLALISERVER22;database=INVSYNCoursesDB;Trusted_Connection=True;");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Courses>()
				.HasOne(c => c.Users)
				.WithMany(u => u.Courses)
				.HasForeignKey(c => c.UserId);
		}
		public DbSet<Courses> Courses { get; set; }
		public DbSet<Users> Users { get; set; }
		
	}
}
