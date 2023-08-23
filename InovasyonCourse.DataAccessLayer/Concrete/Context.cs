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
			modelBuilder.Entity<UserCourse>()
	   .HasKey(uc => new { uc.UserId, uc.CourseId });//tabloda birden fazla ıd var ara tablo olduğu için onu bildirdim. Bu tablo öğrenci kursu seçebilmesi için

			modelBuilder.Entity<UserCourse>()
				.HasOne(uc => uc.Users)
				.WithMany(u => u.UserCourses)
				.HasForeignKey(uc => uc.UserId);

			modelBuilder.Entity<UserCourse>()
				.HasOne(uc => uc.Courses)
				.WithMany(c => c.UserCourses) 
				.HasForeignKey(uc => uc.CourseId);
		}
		public virtual DbSet<Courses> Courses { get; set; } = null!;
		public virtual DbSet<Users> Users { get; set; } = null!;
		public virtual DbSet<UserCourse> UserCourses { get; set; } = null!;

	}
}
