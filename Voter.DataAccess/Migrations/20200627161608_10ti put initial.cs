﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Voter.EfDataAccess.Migrations
{
    public partial class _10tiputinitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Actor = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UseCaseLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Actor = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Data = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UseCaseLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleUseCase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    UseCaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUseCase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleUseCase_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Info = table.Column<string>(nullable: false),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    PersonalId = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    RegionId = table.Column<int>(nullable: false),
                    OptionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Persons_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Voter" },
                    { 2, "Admin" },
                    { 3, "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Serbia" },
                    { 2, "Montenegro" },
                    { 3, "Macedonia" },
                    { 4, "Greece" },
                    { 5, "Russia" }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "Info", "Name", "StateId" },
                values: new object[,]
                {
                    { 5, "Neki podaci 2", "Opcija 2", 2 },
                    { 4, "Neki podaci 1", "Opcija 1", 2 },
                    { 1, "Some data 1", "Vote Option 1", 1 },
                    { 2, "Some data 2", "Vote Option 2", 1 },
                    { 3, "Some data 3", "Vote Option 3", 1 }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Name", "StateId" },
                values: new object[,]
                {
                    { 6, "Zeta", 2 },
                    { 5, "Primorje", 2 },
                    { 2, "Sumadija", 1 },
                    { 3, "Vojvodina", 1 },
                    { 4, "Kosovo", 1 },
                    { 1, "Rasinski Okrug", 1 }
                });

            migrationBuilder.InsertData(
                table: "RoleUseCase",
                columns: new[] { "Id", "RoleId", "UseCaseId" },
                values: new object[,]
                {
                    { 15, 3, 8 },
                    { 17, 3, 9 },
                    { 19, 3, 10 },
                    { 21, 3, 11 },
                    { 23, 3, 12 },
                    { 25, 3, 13 },
                    { 27, 3, 14 },
                    { 28, 3, 15 },
                    { 30, 3, 16 },
                    { 34, 3, 18 },
                    { 36, 3, 19 },
                    { 37, 3, 20 },
                    { 13, 3, 7 },
                    { 41, 3, 22 },
                    { 42, 3, 23 },
                    { 45, 3, 24 },
                    { 49, 3, 25 },
                    { 52, 3, 26 },
                    { 32, 3, 17 },
                    { 39, 3, 21 },
                    { 11, 3, 6 },
                    { 5, 3, 4 },
                    { 9, 1, 6 },
                    { 43, 1, 24 },
                    { 46, 1, 14 },
                    { 47, 1, 25 },
                    { 50, 1, 26 },
                    { 4, 2, 4 },
                    { 7, 2, 5 },
                    { 10, 2, 6 },
                    { 12, 2, 7 },
                    { 14, 2, 8 },
                    { 16, 2, 9 },
                    { 18, 2, 10 },
                    { 20, 2, 11 },
                    { 8, 3, 5 },
                    { 22, 2, 12 },
                    { 26, 2, 14 },
                    { 29, 2, 16 },
                    { 31, 2, 17 },
                    { 33, 2, 18 },
                    { 35, 2, 19 },
                    { 38, 2, 21 },
                    { 40, 2, 22 },
                    { 44, 2, 24 },
                    { 48, 2, 25 },
                    { 51, 2, 26 },
                    { 1, 3, 1 },
                    { 2, 3, 2 },
                    { 3, 3, 3 },
                    { 24, 2, 13 },
                    { 6, 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "FirstName", "LastName", "OptionId", "Password", "PersonalId", "RegionId", "RoleId" },
                values: new object[,]
                {
                    { 1, "Neka bb", "Marko", "Markovic", 1, "/21hcmtvMQ==", "0102448272957", 1, 1 },
                    { 12, "Neka bb", "Djordje", "Djordjevic", 5, "/21hcmtvMQ==", "8102448272957", 6, 1 },
                    { 11, "Neka bb", "Bilja", "Biljic", 5, "/21hcmtvMQ==", "7102448272957", 5, 1 },
                    { 10, "Neka bb", "Mladen", "Mladenovic", 5, "/21hcmtvMQ==", "6102448272957", 5, 1 },
                    { 9, "Neka bb", "Jelena", "Jelenic", 5, "/21hcmtvMQ==", "5102448272957", 5, 1 },
                    { 8, "Neka bb", "Aleks", "Aleksic", 5, "/21hcmtvMQ==", "4102448272957", 5, 1 },
                    { 19, "Neka bb", "Jovana", "Jovanic", 2, "/21hcmtvMQ==", "1702448272957", 2, 1 },
                    { 18, "Neka bb", "Dijana", "Dijanic", 2, "/21hcmtvMQ==", "1602448272957", 2, 1 },
                    { 13, "Neka bb", "Uros", "Urosevic", 5, "/21hcmtvMQ==", "9102448272957", 6, 1 },
                    { 17, "Neka bb", "Vladimir", "Vladimirovic", 2, "/21hcmtvMQ==", "1502448272957", 2, 1 },
                    { 15, "Neka bb", "Milena", "Milenic", 2, "/21hcmtvMQ==", "1302448272957", 1, 1 },
                    { 7, "Neka bb", "Kata", "Katic", 1, "/21hcmtvMQ==", "3102448272957", 1, 1 },
                    { 6, "Neka bb", "Jana", "Janic", 1, "/21hcmtvMQ==", "2102448272957", 1, 1 },
                    { 5, "Neka bb", "Branko", "Branic", 1, "/21hcmtvMQ==", "1102448472957", 1, 1 },
                    { 4, "Neka bb", "Mare", "Maric", 1, "/21hcmtvMQ==", "1102448272957", 1, 1 },
                    { 3, "Adresa na Zemlji", "Ana", "Anic", 1, "/2FuYTE=", "4947330764844", 1, 3 },
                    { 2, "Druga bb", "Nikola", "Nikolic", 1, "/25pa29sYTE=", "9475038857393", 1, 2 },
                    { 16, "Neka bb", "Nevena", "Nevenkic", 2, "/21hcmtvMQ==", "1402448272957", 1, 1 },
                    { 14, "Neka bb", "Stefan", "Stefanovic", 5, "/21hcmtvMQ==", "1202448272957", 6, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Options_StateId",
                table: "Options",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_OptionId",
                table: "Persons",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonalId",
                table: "Persons",
                column: "PersonalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_RegionId",
                table: "Persons",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_RoleId",
                table: "Persons",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_StateId",
                table: "Regions",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_Name",
                table: "Reports",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleUseCase_RoleId",
                table: "RoleUseCase",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_States_Name",
                table: "States",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "RoleUseCase");

            migrationBuilder.DropTable(
                name: "UseCaseLogs");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}