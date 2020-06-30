using Microsoft.EntityFrameworkCore.Migrations;

namespace Voter.EfDataAccess.Migrations
{
    public partial class rightsforusersadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoleUseCase",
                columns: new[] { "Id", "RoleId", "UseCaseId" },
                values: new object[,]
                {
                    { 56, 1, 15 },
                    { 57, 2, 15 },
                    { 58, 1, 3 },
                    { 59, 2, 3 },
                    { 60, 1, 16 },
                    { 61, 1, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleUseCase",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "RoleUseCase",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "RoleUseCase",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "RoleUseCase",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "RoleUseCase",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "RoleUseCase",
                keyColumn: "Id",
                keyValue: 61);
        }
    }
}
