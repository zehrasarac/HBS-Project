using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HbSystem.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatientDiagnosis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientDiagnoses_Doctors_DoctorId",
                table: "PatientDiagnoses");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientDiagnoses_Patients_PatientId",
                table: "PatientDiagnoses");

            migrationBuilder.DropIndex(
                name: "IX_PatientDiagnoses_DoctorId",
                table: "PatientDiagnoses");

            migrationBuilder.DropIndex(
                name: "IX_PatientDiagnoses_PatientId",
                table: "PatientDiagnoses");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "PatientDiagnoses");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "PatientDiagnoses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "PatientDiagnoses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "PatientDiagnoses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiagnoses_DoctorId",
                table: "PatientDiagnoses",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiagnoses_PatientId",
                table: "PatientDiagnoses",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDiagnoses_Doctors_DoctorId",
                table: "PatientDiagnoses",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDiagnoses_Patients_PatientId",
                table: "PatientDiagnoses",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
