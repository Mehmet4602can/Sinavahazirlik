using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hazırlık.Migrations
{
    public partial class mssqllocal_migration_969 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Siniflar",
                columns: table => new
                {
                    SinifID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinifAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SinifKodu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siniflar", x => x.SinifID);
                });

            migrationBuilder.CreateTable(
                name: "Ogrenciler",
                columns: table => new
                {
                    OgrenciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OgrenciSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SinifID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrenciler", x => x.OgrenciID);
                    table.ForeignKey(
                        name: "FK_Ogrenciler_Siniflar_SinifID",
                        column: x => x.SinifID,
                        principalTable: "Siniflar",
                        principalColumn: "SinifID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ogrenciler_SinifID",
                table: "Ogrenciler",
                column: "SinifID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ogrenciler");

            migrationBuilder.DropTable(
                name: "Siniflar");
        }
    }
}
