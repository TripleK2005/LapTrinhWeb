using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab09_v2.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nth_LoaiSanPham",
                columns: table => new
                {
                    nthId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nthMaLoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nthTenLoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nthTrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nth_LoaiSanPham", x => x.nthId);
                });

            migrationBuilder.CreateTable(
                name: "nth_SanPham",
                columns: table => new
                {
                    nthId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nthMaSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nthTenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nthHinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nthSoLuong = table.Column<int>(type: "int", nullable: false),
                    nthDonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    nthLoaiId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nth_SanPham", x => x.nthId);
                    table.ForeignKey(
                        name: "FK_nth_SanPham_nth_LoaiSanPham_nthLoaiId",
                        column: x => x.nthLoaiId,
                        principalTable: "nth_LoaiSanPham",
                        principalColumn: "nthId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_nth_SanPham_nthLoaiId",
                table: "nth_SanPham",
                column: "nthLoaiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nth_SanPham");

            migrationBuilder.DropTable(
                name: "nth_LoaiSanPham");
        }
    }
}
