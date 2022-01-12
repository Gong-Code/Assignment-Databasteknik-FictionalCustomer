using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FictionalCustomer.UI.Data.Migrations
{
    public partial class AddedPorgrammerList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Employees_ProgrammerId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_ProgrammerId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "ProgrammerId",
                table: "Assignments");

            migrationBuilder.CreateTable(
                name: "AssignmentProgrammer",
                columns: table => new
                {
                    AssignmentsId = table.Column<int>(type: "int", nullable: false),
                    ProgrammerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentProgrammer", x => new { x.AssignmentsId, x.ProgrammerId });
                    table.ForeignKey(
                        name: "FK_AssignmentProgrammer_Assignments_AssignmentsId",
                        column: x => x.AssignmentsId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignmentProgrammer_Employees_ProgrammerId",
                        column: x => x.ProgrammerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentProgrammer_ProgrammerId",
                table: "AssignmentProgrammer",
                column: "ProgrammerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignmentProgrammer");

            migrationBuilder.AddColumn<int>(
                name: "ProgrammerId",
                table: "Assignments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_ProgrammerId",
                table: "Assignments",
                column: "ProgrammerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Employees_ProgrammerId",
                table: "Assignments",
                column: "ProgrammerId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
