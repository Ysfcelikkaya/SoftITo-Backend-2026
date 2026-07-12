using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalAppApi.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LabAndXRayResults",
                table: "MedicalRecords",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medicines",
                table: "MedicalRecords",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReportDate",
                table: "MedicalRecords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LabAndXRayResults",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "Medicines",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "ReportDate",
                table: "MedicalRecords");
        }
    }
}
