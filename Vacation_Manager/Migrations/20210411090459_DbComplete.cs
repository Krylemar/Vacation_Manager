using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Vacation_Manager.Migrations
{
    public partial class DbComplete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProjectName = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TeamName = table.Column<string>(maxLength: 20, nullable: false),
                    TeamLead = table.Column<int>(nullable: true),
                    TeamProject = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Project",
                        column: x => x.TeamProject,
                        principalTable: "projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    Role = table.Column<string>(type: "enum('CEO','Team Lead','Developer','Unassigned')", nullable: false),
                    UserTeam = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserTeam",
                        column: x => x.UserTeam,
                        principalTable: "teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vacations",
                columns: table => new
                {
                    VacationId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsApproved = table.Column<bool>(nullable: true),
                    VacUser = table.Column<int>(nullable: false),
                    VacType = table.Column<string>(type: "enum('Paid','Unpaid','Sick')", nullable: true),
                    IsApprovedByCEO = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.VacationId);
                    table.ForeignKey(
                        name: "FK_User",
                        column: x => x.VacUser,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "FK_Leader",
                table: "teams",
                column: "TeamLead");

            migrationBuilder.CreateIndex(
                name: "FK_Project",
                table: "teams",
                column: "TeamProject");

            migrationBuilder.CreateIndex(
                name: "UserId_UNIQUE",
                table: "users",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_UserTeam",
                table: "users",
                column: "UserTeam");

            migrationBuilder.CreateIndex(
                name: "FK_User",
                table: "vacations",
                column: "VacUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Leader",
                table: "teams",
                column: "TeamLead",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leader",
                table: "teams");

            migrationBuilder.DropTable(
                name: "vacations");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "teams");

            migrationBuilder.DropTable(
                name: "projects");
        }
    }
}
