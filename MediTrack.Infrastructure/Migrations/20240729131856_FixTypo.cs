using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_Patients_PatientId",
                table: "MedicalRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_Physicians_PhysicianId",
                table: "MedicalRecords");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecords_PatientId",
                table: "MedicalRecords");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecords_PhysicianId",
                table: "MedicalRecords");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_PatientId",
                table: "MedicalRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_PhysicianId",
                table: "MedicalRecords",
                column: "PhysicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_Patients_PatientId",
                table: "MedicalRecords",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_Physicians_PhysicianId",
                table: "MedicalRecords",
                column: "PhysicianId",
                principalTable: "Physicians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
