using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio_website.Data.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    Experience_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Domain_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.Experience_Id);
                });

            migrationBuilder.CreateTable(
                name: "Portfolio_Data",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Proj_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Proj_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Proj_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Proj_Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pic_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pic_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pic_3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    video = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    proj_code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolio_Data", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.DropTable(
                name: "Portfolio_Data");
        }
    }
}
