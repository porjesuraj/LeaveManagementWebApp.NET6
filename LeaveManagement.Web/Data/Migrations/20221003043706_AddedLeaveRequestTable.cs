using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedLeaveRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    RequestingEmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

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
    }
}
