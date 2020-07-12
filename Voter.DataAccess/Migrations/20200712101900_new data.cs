using Microsoft.EntityFrameworkCore.Migrations;

namespace Voter.EfDataAccess.Migrations
{
    public partial class newdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "FirstName", "LastName", "OptionId", "Password", "PersonalId", "RegionId", "RoleId" },
                values: new object[] { 20, "Neka bb", "Ivana", "Ivanovic", 2, "/2l2YW5hMQ==", "1702443372957", 2, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
