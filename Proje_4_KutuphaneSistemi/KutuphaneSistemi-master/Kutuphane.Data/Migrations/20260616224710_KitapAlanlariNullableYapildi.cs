using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kutuphane.Data.Migrations
{
    /// <inheritdoc />
    public partial class KitapAlanlariNullableYapildi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitaps_Kategoris_KategoriNo",
                table: "Kitaps");

            migrationBuilder.DropForeignKey(
                name: "FK_Kitaps_Yazars_YazarNo",
                table: "Kitaps");

            migrationBuilder.AlterColumn<int>(
                name: "YazarNo",
                table: "Kitaps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "KitapAdi",
                table: "Kitaps",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<int>(
                name: "KategoriNo",
                table: "Kitaps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitaps_Kategoris_KategoriNo",
                table: "Kitaps",
                column: "KategoriNo",
                principalTable: "Kategoris",
                principalColumn: "KategoriNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitaps_Yazars_YazarNo",
                table: "Kitaps",
                column: "YazarNo",
                principalTable: "Yazars",
                principalColumn: "YazarNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitaps_Kategoris_KategoriNo",
                table: "Kitaps");

            migrationBuilder.DropForeignKey(
                name: "FK_Kitaps_Yazars_YazarNo",
                table: "Kitaps");

            migrationBuilder.AlterColumn<int>(
                name: "YazarNo",
                table: "Kitaps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KitapAdi",
                table: "Kitaps",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "KategoriNo",
                table: "Kitaps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kitaps_Kategoris_KategoriNo",
                table: "Kitaps",
                column: "KategoriNo",
                principalTable: "Kategoris",
                principalColumn: "KategoriNo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kitaps_Yazars_YazarNo",
                table: "Kitaps",
                column: "YazarNo",
                principalTable: "Yazars",
                principalColumn: "YazarNo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
