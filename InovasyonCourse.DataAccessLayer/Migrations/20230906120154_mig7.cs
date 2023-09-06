using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InovasyonCourse.DataAccessLayer.Migrations
{
    public partial class mig7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0660b32c-6e07-4b35-a49f-951aeb871609"), "74ce42e9-6254-4032-a29c-78b6d69f8781", "Admin", "ADMIN" },
                    { new Guid("a897856b-fd7b-4bb1-ab38-d38e6a607950"), "7562b4e5-f815-4f1c-960b-0a806d175cf8", "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("5ee3076b-2562-4cc3-ae72-e44f7408a058"), 0, new DateTime(1988, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "7a5513bd-ba58-4e45-8c40-c7bb0679d6a4", "hazel.calkar@bilgeadamboost.com", false, "Hazel", "ÇALKAR", false, null, "HAZEL.CALKAR@BILGEADAMBOOST.COM", "HAZELC", "AQAAAAEAACcQAAAAEBePaxZPuec9AEXjCl3U7dNr0ONzAT/GXIo4HV+B7ug5oqswPTRcIncf6oz0DXd6cQ==", null, false, "afa91c0e-0643-430a-8d81-0ae04492a213", false, "HazelC" },
                    { new Guid("8300c0ef-1013-40b3-be67-93d8eaf125ec"), 0, new DateTime(1997, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "39abd020-5254-441e-a767-661c044a0a74", "ramazan.yaylali@bilgeadamboost.com", false, "Ramazan", "YAYLALI", false, null, "RAMAZAN.YAYLALI@BILGEADAMBOOST.COM", "RAMAZANY", "AQAAAAEAACcQAAAAEAi93jRDti1VxERtrfA4hS0dGRQRZwHUeC4iCDE0uQK5bCGJLK+YtbBw5EgzgT5LHQ==", null, false, "492f7394-4d61-4387-9552-5f17d3faff94", false, "RamazanY" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[] { new Guid("a897856b-fd7b-4bb1-ab38-d38e6a607950"), new Guid("5ee3076b-2562-4cc3-ae72-e44f7408a058"), "AspNetUserRole" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[] { new Guid("0660b32c-6e07-4b35-a49f-951aeb871609"), new Guid("8300c0ef-1013-40b3-be67-93d8eaf125ec"), "AspNetUserRole" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a897856b-fd7b-4bb1-ab38-d38e6a607950"), new Guid("5ee3076b-2562-4cc3-ae72-e44f7408a058") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("0660b32c-6e07-4b35-a49f-951aeb871609"), new Guid("8300c0ef-1013-40b3-be67-93d8eaf125ec") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0660b32c-6e07-4b35-a49f-951aeb871609"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a897856b-fd7b-4bb1-ab38-d38e6a607950"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5ee3076b-2562-4cc3-ae72-e44f7408a058"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8300c0ef-1013-40b3-be67-93d8eaf125ec"));

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
