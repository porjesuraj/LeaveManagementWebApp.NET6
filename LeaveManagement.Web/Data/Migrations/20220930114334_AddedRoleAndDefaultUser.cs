using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedRoleAndDefaultUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d3cf024-2e3e-2323-9a8e-2796bcead059", "64b2f606-9026-40f0-a529-fe7ca9bb179f", "User", "USER" },
                    { "2d6cf024-2e3e-4249-9a8e-2796bcead059", "9b7fada0-210f-4450-a838-37000de200e1", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "JoiningDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5910682d-2b54-4edc-232d-44df1f0b1190", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8c499697-304e-4910-b9ef-d7c43d5de094", "user@gmail.com", false, "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", false, null, "USER@GMAIL.COM", null, "AQAAAAEAACcQAAAAECwUk6M+1oVl9gxqEnrOGt5O4Q37Oeo7UDlhCDphPs7n6y5QhIvi5e9cJr6VxAMWhQ==", null, false, "78c70217-9eb4-4725-b146-3c44314cc37c", null, false, null },
                    { "5910682d-2b54-4edc-935d-44df2f0b2290", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b6cc2f80-1a2f-4e93-ada5-941b7042889c", "porjesuraj@gmail.com", false, "Suraj", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Porje", false, null, "PORJESURAJ@GMAIL.COM", null, "AQAAAAEAACcQAAAAEB9q6mYt1N3XzyzWKX6nDYm8+6JQiqfwFBEDlr9894ABfDTdyMr2BM04d3gAs5Fayg==", null, false, "b18b6557-3549-4d80-bf48-e85c4ec21f5f", null, false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2d3cf024-2e3e-2323-9a8e-2796bcead059", "5910682d-2b54-4edc-232d-44df1f0b1190" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2d6cf024-2e3e-4249-9a8e-2796bcead059", "5910682d-2b54-4edc-935d-44df2f0b2290" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2d3cf024-2e3e-2323-9a8e-2796bcead059", "5910682d-2b54-4edc-232d-44df1f0b1190" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2d6cf024-2e3e-4249-9a8e-2796bcead059", "5910682d-2b54-4edc-935d-44df2f0b2290" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d3cf024-2e3e-2323-9a8e-2796bcead059");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d6cf024-2e3e-4249-9a8e-2796bcead059");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5910682d-2b54-4edc-232d-44df1f0b1190");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5910682d-2b54-4edc-935d-44df2f0b2290");
        }
    }
}
