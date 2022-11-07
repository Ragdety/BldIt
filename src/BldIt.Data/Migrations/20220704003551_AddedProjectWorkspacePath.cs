using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BldIt.Data.Migrations
{
    public partial class AddedProjectWorkspacePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectWorkspacePath",
                table: "Projects",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectWorkspacePath",
                table: "Projects");
        }
    }
}
