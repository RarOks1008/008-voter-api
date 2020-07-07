using Microsoft.EntityFrameworkCore.Migrations;

namespace Voter.EfDataAccess.Migrations
{
    public partial class getreportsandusecaselogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoleUseCase",
                columns: new[] { "Id", "RoleId", "UseCaseId" },
                values: new object[] { 71, 3, 33 });

            migrationBuilder.InsertData(
                table: "RoleUseCase",
                columns: new[] { "Id", "RoleId", "UseCaseId" },
                values: new object[] { 72, 3, 34 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleUseCase",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "RoleUseCase",
                keyColumn: "Id",
                keyValue: 72);
        }
    }
}
