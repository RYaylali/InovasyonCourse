using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InovasyonCourse.DataAccessLayer.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("767d442b-b4fe-4088-9c3c-48bcd736527b"), "deb93c01-9d34-4549-93d3-14bf970a462e", "Student", "STUDENT" },
                    { new Guid("9a08def7-5b8c-45e7-bf09-02c0d42a5542"), "850b7596-444f-4fbe-91bb-db55b57867e9", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("190303a9-df2a-4fe3-990f-61160568f426"), 0, new DateTime(1988, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "f77deb3c-9fb5-4e59-ab7b-18dcf17be443", "hazel.calkar@bilgeadamboost.com", false, "Hazel", "ÇALKAR", false, null, "HAZEL.CALKAR@BILGEADAMBOOST.COM", "HAZELC", "AQAAAAEAACcQAAAAEKF4T4UN8i9mkApXMo0rAWC5uTWVyKB74CH8YQ+Cazd8xHPv1rHg+wptbeEO/L/buw==", null, false, 0, "07cea342-13b5-49c6-906a-3327f7ddc5e9", false, "HazelC" },
                    { new Guid("83730e42-dc94-4983-8746-4c374e1bd751"), 0, new DateTime(1997, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "d39cb49b-33a5-4f3a-a507-0e0c7eb11754", "ramazan.yaylali@bilgeadamboost.com", false, "Ramazan", "YAYLALI", false, null, "RAMAZAN.YAYLALI@BILGEADAMBOOST.COM", "RAMAZANY", "AQAAAAEAACcQAAAAEM1KXSARU5XCpW1s6YexQEHy7E8+N8yS/LnHZLbOiC08cwB+a/bD+eciQIXUSnQwCA==", null, false, 0, "075704a8-5513-4833-9957-488bf670fd59", false, "RamazanY" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[] { new Guid("767d442b-b4fe-4088-9c3c-48bcd736527b"), new Guid("190303a9-df2a-4fe3-990f-61160568f426"), "AspNetUserRole" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[] { new Guid("9a08def7-5b8c-45e7-bf09-02c0d42a5542"), new Guid("83730e42-dc94-4983-8746-4c374e1bd751"), "AspNetUserRole" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("767d442b-b4fe-4088-9c3c-48bcd736527b"), new Guid("190303a9-df2a-4fe3-990f-61160568f426") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9a08def7-5b8c-45e7-bf09-02c0d42a5542"), new Guid("83730e42-dc94-4983-8746-4c374e1bd751") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("767d442b-b4fe-4088-9c3c-48bcd736527b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9a08def7-5b8c-45e7-bf09-02c0d42a5542"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("190303a9-df2a-4fe3-990f-61160568f426"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("83730e42-dc94-4983-8746-4c374e1bd751"));

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserRoles");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
