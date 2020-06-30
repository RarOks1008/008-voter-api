using Microsoft.EntityFrameworkCore.Migrations;

namespace Voter.EfDataAccess.Migrations
{
    public partial class addedgetmyvote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoleUseCase",
                columns: new[] { "Id", "RoleId", "UseCaseId" },
                values: new object[] { 53, 1, 27 });

            migrationBuilder.InsertData(
                table: "RoleUseCase",
                columns: new[] { "Id", "RoleId", "UseCaseId" },
                values: new object[] { 54, 2, 27 });

            migrationBuilder.InsertData(
                table: "RoleUseCase",
                columns: new[] { "Id", "RoleId", "UseCaseId" },
                values: new object[] { 55, 3, 27 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleUseCase",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "RoleUseCase",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "RoleUseCase",
                keyColumn: "Id",
                keyValue: 55);
        }
    }
}
