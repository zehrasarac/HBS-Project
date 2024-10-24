using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HbSystem.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Diagnoses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_DepartmentId",
                table: "Diagnoses",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_Departments_DepartmentId",
                table: "Diagnoses",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Departments_DepartmentId",
                table: "Diagnoses");

            migrationBuilder.DropIndex(
                name: "IX_Diagnoses_DepartmentId",
                table: "Diagnoses");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Diagnoses");
        }
    }
}
