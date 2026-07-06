using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OgrenciSistemi.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ogrencis_Bolums_BolumNo1",
                table: "Ogrencis");

            migrationBuilder.DropIndex(
                name: "IX_Ogrencis_BolumNo1",
                table: "Ogrencis");

            migrationBuilder.DropColumn(
                name: "BolumNo1",
                table: "Ogrencis");

            migrationBuilder.CreateIndex(
                name: "IX_Ogrencis_BolumNo",
                table: "Ogrencis",
                column: "BolumNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Ogrencis_Bolums_BolumNo",
                table: "Ogrencis",
                column: "BolumNo",
                principalTable: "Bolums",
                principalColumn: "BolumNo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ogrencis_Bolums_BolumNo",
                table: "Ogrencis");

            migrationBuilder.DropIndex(
                name: "IX_Ogrencis_BolumNo",
                table: "Ogrencis");

            migrationBuilder.AddColumn<int>(
                name: "BolumNo1",
                table: "Ogrencis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ogrencis_BolumNo1",
                table: "Ogrencis",
                column: "BolumNo1");

            migrationBuilder.AddForeignKey(
                name: "FK_Ogrencis_Bolums_BolumNo1",
                table: "Ogrencis",
                column: "BolumNo1",
                principalTable: "Bolums",
                principalColumn: "BolumNo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
