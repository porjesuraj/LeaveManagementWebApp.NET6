using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedPeriodToLeaveAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d3cf024-2e3e-2323-9a8e-2796bcead059",
                column: "ConcurrencyStamp",
                value: "75e9a4e3-9b2c-4c79-8c91-f802d7472eeb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d6cf024-2e3e-4249-9a8e-2796bcead059",
                column: "ConcurrencyStamp",
                value: "c6926f44-286f-4e21-adf1-c815d8f145a8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5910682d-2b54-4edc-232d-44df1f0b1190",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5ddd38c-3633-4ec1-9059-ee0531e2158d", "AQAAAAEAACcQAAAAEG1W8emKk4x12MKlRTXm2o9s6sUcoYiXxSdcDepiDXRjUfl7A4BsEw4tWC1PgEGhGg==", "b8da99f2-7c72-4021-8cc8-080fc99c2c04" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5910682d-2b54-4edc-935d-44df2f0b2290",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7fb5c5cd-d840-44fe-8cdd-2b85668d792d", "AQAAAAEAACcQAAAAEHX+T+x3uD7xzvxANYeaSHqqF6gAIkp/ODcUikQVOPMRGDHShbcrs/ZVzbLMnVJNng==", "283353db-1f52-4b5f-a8de-337c5a96a07a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52cacaa2-4632-44df-ba84-f559217102ac", "AQAAAAEAACcQAAAAEAyrcc7dIAOI1cNe+GFQWeDF7rtKiucUZF+c5q16GU5Oxoulw3QsRKbSzOs8JRWlOg==", "d5de4e41-e99b-4f24-a1a2-0eadd7e45070" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5910682d-2b54-4edc-935d-44df2f0b2290",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b23b374-5887-4193-84b8-460beb095721", "AQAAAAEAACcQAAAAEF0W4FkkGRoi3tsErUYY2Y1yb3zAh0o6Mu+wEqSImSrS/r/4DuTBH29b031aCQHp+w==", "8ed3865f-0fca-4bea-bb86-f40f9f06a89b" });
        }
    }
}
