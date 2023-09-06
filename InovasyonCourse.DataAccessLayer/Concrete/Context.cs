using InovasyonCourse.CoreLayer;
using InovasyonCourse.CoreLayer.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InovasyonCourse.DataAccessLayer.Concrete
{
	public class Context : IdentityDbContext<AppNetUser,AppNetRole,Guid>
	{
		public Context(DbContextOptions<Context> options) : base(options)
		{
		}

		//	protected override void OnModelCreating(ModelBuilder modelBuilder)
		//	{
		//		modelBuilder.Entity<IdentityUser>()
		//.HasKey(u => u.Id);
		//		modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
		//		modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
		//		modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();


		//	}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			SeedData.SeedData.Seed(builder);
			base.OnModelCreating(builder);
		}
		public virtual DbSet<Courses> Courses { get; set; } = null!;
	}
}
