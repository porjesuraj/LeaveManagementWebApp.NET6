using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class UpdatedRoleAndDefaultUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d3cf024-2e3e-2323-9a8e-2796bcead059",
                column: "ConcurrencyStamp",
                value: "dedcb398-4278-4ddd-821d-cd23834874e7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d6cf024-2e3e-4249-9a8e-2796bcead059",
                column: "ConcurrencyStamp",
                value: "c380d2a1-d32d-4ca0-92b9-ef94573e6570");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5910682d-2b54-4edc-232d-44df1f0b1190",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "52cacaa2-4632-44df-ba84-f559217102ac", true, "USER@GMAIL.COM", "AQAAAAEAACcQAAAAEAyrcc7dIAOI1cNe+GFQWeDF7rtKiucUZF+c5q16GU5Oxoulw3QsRKbSzOs8JRWlOg==", "d5de4e41-e99b-4f24-a1a2-0eadd7e45070", "user@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5910682d-2b54-4edc-935d-44df2f0b2290",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "9b23b374-5887-4193-84b8-460beb095721", true, "PORJESURAJ@GMAIL.COM", "AQAAAAEAACcQAAAAEF0W4FkkGRoi3tsErUYY2Y1yb3zAh0o6Mu+wEqSImSrS/r/4DuTBH29b031aCQHp+w==", "8ed3865f-0fca-4bea-bb86-f40f9f06a89b", "porjesuraj@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d3cf024-2e3e-2323-9a8e-2796bcead059",
                column: "ConcurrencyStamp",
                value: "64b2f606-9026-40f0-a529-fe7ca9bb179f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d6cf024-2e3e-4249-9a8e-2796bcead059",
                column: "ConcurrencyStamp",
                value: "9b7fada0-210f-4450-a838-37000de200e1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5910682d-2b54-4edc-232d-44df1f0b1190",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8c499697-304e-4910-b9ef-d7c43d5de094", false, null, "AQAAAAEAACcQAAAAECwUk6M+1oVl9gxqEnrOGt5O4Q37Oeo7UDlhCDphPs7n6y5QhIvi5e9cJr6VxAMWhQ==", "78c70217-9eb4-4725-b146-3c44314cc37c", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5910682d-2b54-4edc-935d-44df2f0b2290",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b6cc2f80-1a2f-4e93-ada5-941b7042889c", false, null, "AQAAAAEAACcQAAAAEB9q6mYt1N3XzyzWKX6nDYm8+6JQiqfwFBEDlr9894ABfDTdyMr2BM04d3gAs5Fayg==", "b18b6557-3549-4d80-bf48-e85c4ec21f5f", null });
        }
    }
}
