using Microsoft.EntityFrameworkCore.Migrations;

namespace Voter.EfDataAccess.Migrations
{
    public partial class addedparties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartyId",
                table: "Options",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Partys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partys", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Partys",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Republican" });

            migrationBuilder.InsertData(
                table: "Partys",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Democrats" });

            migrationBuilder.CreateIndex(
                name: "IX_Options_PartyId",
                table: "Options",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Partys_Name",
                table: "Partys",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Partys_PartyId",
                table: "Options",
                column: "PartyId",
                principalTable: "Partys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Partys_PartyId",
                table: "Options");

            migrationBuilder.DropTable(
                name: "Partys");

            migrationBuilder.DropIndex(
                name: "IX_Options_PartyId",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "PartyId",
                table: "Options");
        }
    }
}
