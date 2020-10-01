using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Api.Migrations
{
    public partial class InitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaBarang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Harga = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BarangPembelis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BarangId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarangPembelis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarangPembelis_Barangs_BarangId",
                        column: x => x.BarangId,
                        principalTable: "Barangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BarangPembelis_BarangId",
                table: "BarangPembelis",
                column: "BarangId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarangPembelis");

            migrationBuilder.DropTable(
                name: "Barangs");
        }
    }
}
