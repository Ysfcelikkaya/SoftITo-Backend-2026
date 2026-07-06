using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OgrenciSistemi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bolums",
                columns: table => new
                {
                    BolumNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BolumAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolums", x => x.BolumNo);
                });

            migrationBuilder.CreateTable(
                name: "Derss",
                columns: table => new
                {
                    DersNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DersAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DersKredi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Derss", x => x.DersNo);
                });

            migrationBuilder.CreateTable(
                name: "Ogrencis",
                columns: table => new
                {
                    OgrenciNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OgrenciSinif = table.Column<int>(type: "int", nullable: false),
                    BolumNo = table.Column<int>(type: "int", nullable: false),
                    BolumNo1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrencis", x => x.OgrenciNo);
                    table.ForeignKey(
                        name: "FK_Ogrencis_Bolums_BolumNo1",
                        column: x => x.BolumNo1,
                        principalTable: "Bolums",
                        principalColumn: "BolumNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ogretmens",
                columns: table => new
                {
                    OgretmenNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgretmenAdi = table.Column<int>(type: "int", nullable: false),
                    OgretmenBrans = table.Column<int>(type: "int", nullable: false),
                    BolumNo = table.Column<int>(type: "int", nullable: false),
                    BolumNo1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogretmens", x => x.OgretmenNo);
                    table.ForeignKey(
                        name: "FK_Ogretmens_Bolums_BolumNo1",
                        column: x => x.BolumNo1,
                        principalTable: "Bolums",
                        principalColumn: "BolumNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ogrencis_BolumNo1",
                table: "Ogrencis",
                column: "BolumNo1");

            migrationBuilder.CreateIndex(
                name: "IX_Ogretmens_BolumNo1",
                table: "Ogretmens",
                column: "BolumNo1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Derss");

            migrationBuilder.DropTable(
                name: "Ogrencis");

            migrationBuilder.DropTable(
                name: "Ogretmens");

            migrationBuilder.DropTable(
                name: "Bolums");
        }
    }
}
