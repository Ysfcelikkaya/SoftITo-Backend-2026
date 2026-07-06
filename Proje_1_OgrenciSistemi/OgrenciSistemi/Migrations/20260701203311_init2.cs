using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OgrenciSistemi.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ogretmens_Bolums_BolumNo1",
                table: "Ogretmens");

            migrationBuilder.DropIndex(
                name: "IX_Ogretmens_BolumNo1",
                table: "Ogretmens");

            migrationBuilder.DropColumn(
                name: "BolumNo1",
                table: "Ogretmens");

            migrationBuilder.CreateIndex(
                name: "IX_Ogretmens_BolumNo",
                table: "Ogretmens",
                column: "BolumNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Ogretmens_Bolums_BolumNo",
                table: "Ogretmens",
                column: "BolumNo",
                principalTable: "Bolums",
                principalColumn: "BolumNo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ogretmens_Bolums_BolumNo",
                table: "Ogretmens");

            migrationBuilder.DropIndex(
                name: "IX_Ogretmens_BolumNo",
                table: "Ogretmens");

            migrationBuilder.AddColumn<int>(
                name: "BolumNo1",
                table: "Ogretmens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ogretmens_BolumNo1",
                table: "Ogretmens",
                column: "BolumNo1");

            migrationBuilder.AddForeignKey(
                name: "FK_Ogretmens_Bolums_BolumNo1",
                table: "Ogretmens",
                column: "BolumNo1",
                principalTable: "Bolums",
                principalColumn: "BolumNo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
