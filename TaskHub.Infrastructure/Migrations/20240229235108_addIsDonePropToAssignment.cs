using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskHub.Infrastructure.Migrations
{
    public partial class addIsDonePropToAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "Assignments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "Assignments");
        }
    }
}
