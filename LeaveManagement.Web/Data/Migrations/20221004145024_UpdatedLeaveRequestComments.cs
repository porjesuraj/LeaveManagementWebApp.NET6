using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class UpdatedLeaveRequestComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d3cf024-2e3e-2323-9a8e-2796bcead059",
                column: "ConcurrencyStamp",
                value: "23fa7f7f-5272-4c2c-a35a-f569909a96ab");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d6cf024-2e3e-4249-9a8e-2796bcead059",
                column: "ConcurrencyStamp",
                value: "b4e23868-d784-4e72-a3b6-0e76d2e03cc1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5910682d-2b54-4edc-232d-44df1f0b1190",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f391bda-d79c-42b4-a249-b4502bf1e81d", "AQAAAAEAACcQAAAAEPk08OnSFJ60dfOsKujDMaPvSFW34l007BGQBS68Spmd/IvDokuqocmqFbvxU/vPAg==", "33b2671a-7f44-4dfd-8ab3-a0ed3a1915e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5910682d-2b54-4edc-935d-44df2f0b2290",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1688a96c-f977-49f0-bb57-a21212ce12f5", "AQAAAAEAACcQAAAAEDMhX4VOHQ/Py3Gb4YcFBs0pPxPVSvUjArpFKPIh3zfALRwEOa/95cpujTYF8Dz8Ow==", "7285af6b-b8a0-446c-bc7a-c8ef68c49230" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d3cf024-2e3e-2323-9a8e-2796bcead059",
                column: "ConcurrencyStamp",
                value: "fa78bc3c-c2ca-4a87-8802-c5ba553cbe9b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d6cf024-2e3e-4249-9a8e-2796bcead059",
                column: "ConcurrencyStamp",
                value: "19368041-5447-4292-98c1-4871fe1b6f44");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5910682d-2b54-4edc-232d-44df1f0b1190",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1920de60-8de3-48df-9bc2-67e9ede4d4f8", "AQAAAAEAACcQAAAAEMI7hUPrwY6mA6tuodPMZOqkkCFZJNnZZZPwLnW8NUe1hhqP/kFshMAFsq2OshoNRg==", "6a9eea37-da1a-4137-b135-0a216d079b16" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5910682d-2b54-4edc-935d-44df2f0b2290",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8a8b6e1-f8ea-4f4b-b9c5-bfc545882eb1", "AQAAAAEAACcQAAAAEB91ynAJYayeMHXe4n57HiQkVLnvOV1l4vUPoP4kTWnO5XvsdfeYBwfriti8YquTuA==", "2376594c-d0c1-47d8-99a8-f9516d801f4e" });
        }
    }
}
