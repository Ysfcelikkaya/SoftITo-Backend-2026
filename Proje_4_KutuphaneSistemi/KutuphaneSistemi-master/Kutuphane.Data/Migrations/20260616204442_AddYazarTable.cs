using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kutuphane.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddYazarTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YazarNo",
                table: "Kitaps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Yazars",
                columns: table => new
                {
                    YazarNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YazarAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazars", x => x.YazarNo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kitaps_YazarNo",
                table: "Kitaps",
                column: "YazarNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitaps_Yazars_YazarNo",
                table: "Kitaps",
                column: "YazarNo",
                principalTable: "Yazars",
                principalColumn: "YazarNo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitaps_Yazars_YazarNo",
                table: "Kitaps");

            migrationBuilder.DropTable(
                name: "Yazars");

            migrationBuilder.DropIndex(
                name: "IX_Kitaps_YazarNo",
                table: "Kitaps");

            migrationBuilder.DropColumn(
                name: "YazarNo",
                table: "Kitaps");
        }
    }
}
