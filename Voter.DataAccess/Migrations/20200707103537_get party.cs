using Microsoft.EntityFrameworkCore.Migrations;

namespace Voter.EfDataAccess.Migrations
{
    public partial class getparty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoleUseCase",
                columns: new[] { "Id", "RoleId", "UseCaseId" },
                values: new object[,]
                {
                    { 63, 3, 29 },
                    { 64, 2, 28 },
                    { 65, 2, 29 },
                    { 66, 1, 28 },
                    { 67, 1, 29 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleUseCase",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "RoleUseCase",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "RoleUseCase",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "RoleUseCase",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "RoleUseCase",
                keyColumn: "Id",
                keyValue: 67);
        }
    }
}
