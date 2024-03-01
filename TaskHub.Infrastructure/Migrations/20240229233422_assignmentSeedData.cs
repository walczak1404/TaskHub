using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskHub.Infrastructure.Migrations
{
    public partial class assignmentSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "AssignmentID", "AuthorID", "Content", "Date" },
                values: new object[,]
                {
                    { new Guid("816a16c7-ef5e-49e1-bef7-db781ea3f192"), new Guid("b34fd626-5019-4cee-06cb-08dc36578af7"), "Task Number 1", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("816a26c7-ef5e-49e2-bef7-db781ea3f292"), new Guid("b34fd626-5019-4cee-06cb-08dc36578af7"), "Task Number 2", new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("816a36c7-ef5e-49e3-bef7-db781ea3f392"), new Guid("b34fd626-5019-4cee-06cb-08dc36578af7"), "Task Number 3", new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("816a46c7-ef5e-49e4-bef7-db781ea3f492"), new Guid("b34fd626-5019-4cee-06cb-08dc36578af7"), "Task Number 4", new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("816a56c7-ef5e-49e5-bef7-db781ea3f592"), new Guid("b34fd626-5019-4cee-06cb-08dc36578af7"), "Task Number 5", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "AssignmentID",
                keyValue: new Guid("816a16c7-ef5e-49e1-bef7-db781ea3f192"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "AssignmentID",
                keyValue: new Guid("816a26c7-ef5e-49e2-bef7-db781ea3f292"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "AssignmentID",
                keyValue: new Guid("816a36c7-ef5e-49e3-bef7-db781ea3f392"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "AssignmentID",
                keyValue: new Guid("816a46c7-ef5e-49e4-bef7-db781ea3f492"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "AssignmentID",
                keyValue: new Guid("816a56c7-ef5e-49e5-bef7-db781ea3f592"));
        }
    }
}
