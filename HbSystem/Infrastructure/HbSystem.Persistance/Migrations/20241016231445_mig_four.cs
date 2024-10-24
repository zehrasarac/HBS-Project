using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HbSystem.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_four : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "PatientDiagnoses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiagnoses_PatientId",
                table: "PatientDiagnoses",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDiagnoses_Patients_PatientId",
                table: "PatientDiagnoses",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientDiagnoses_Patients_PatientId",
                table: "PatientDiagnoses");

            migrationBuilder.DropIndex(
                name: "IX_PatientDiagnoses_PatientId",
                table: "PatientDiagnoses");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "PatientDiagnoses");
        }
    }
}
