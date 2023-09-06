using InovasyonCourse.CoreLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InovasyonCourse.DataAccessLayer.SeedData
{
	public static class SeedData
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			List<AppNetRole> roles = new List<AppNetRole>() {
				new AppNetRole {Id=Guid.NewGuid(), Name = "Admin", NormalizedName = "ADMIN" },
				new AppNetRole {Id = Guid.NewGuid(), Name = "Student", NormalizedName = "STUDENT" }
			};
			modelBuilder.Entity<AppNetRole>().HasData(roles);
			List<AppNetUser> users = new List<AppNetUser>() {
				new AppNetUser {
					Id=Guid.NewGuid(),
					UserName="RamazanY",
					NormalizedUserName="RAMAZANY",
                    //PasswordHash="12345",
                    FirstName = "Ramazan",
					LastName="YAYLALI",
					BirthDate= new DateTime(1997,01,25),
					Email = "ramazan.yaylali@bilgeadamboost.com",
					NormalizedEmail="ramazan.yaylalı@bılgeadamboost.com".ToUpper(),
					SecurityStamp=Guid.NewGuid().ToString()
				},
				new AppNetUser {
					Id=Guid.NewGuid(),
					UserName="HazelC",
					NormalizedUserName="HAZELC",
                    FirstName = "Hazel",
					LastName="ÇALKAR",
					BirthDate= new DateTime(1988,05,08),
					Email = "hazel.calkar@bilgeadamboost.com",
					NormalizedEmail="hazel.calkar@bılgeadamboost.com".ToUpper(),
					SecurityStamp=Guid.NewGuid().ToString(),
				}
			};
			modelBuilder.Entity<AppNetUser>().HasData(users);
			var passwordHasher = new PasswordHasher<AppNetUser>();
			users[0].PasswordHash = passwordHasher.HashPassword(users[0], "1234");
			users[1].PasswordHash = passwordHasher.HashPassword(users[1], "1234");
			List<AspNetUserRole> userRoles = new List<AspNetUserRole>();
			userRoles.Add(new AspNetUserRole
			{
				UserId = users[0].Id,
				RoleId = roles.First(q => q.Name == "Admin").Id
			});
			userRoles.Add(new AspNetUserRole
			{
				UserId = users[1].Id,
				RoleId = roles.First(q => q.Name == "Student").Id
			});
			
			modelBuilder.Entity<AspNetUserRole>().HasData(userRoles);
		}

	}
}
