using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HbSystem.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_three : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReferralId",
                table: "PatientDiagnoses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiagnoses_ReferralId",
                table: "PatientDiagnoses",
                column: "ReferralId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDiagnoses_Referrals_ReferralId",
                table: "PatientDiagnoses",
                column: "ReferralId",
                principalTable: "Referrals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientDiagnoses_Referrals_ReferralId",
                table: "PatientDiagnoses");

            migrationBuilder.DropIndex(
                name: "IX_PatientDiagnoses_ReferralId",
                table: "PatientDiagnoses");

            migrationBuilder.DropColumn(
                name: "ReferralId",
                table: "PatientDiagnoses");
        }
    }
}
