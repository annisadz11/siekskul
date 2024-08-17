using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace siekskul.Migrations
{
    /// <inheritdoc />
    public partial class AddModelToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Gurus",
                columns: table => new
                {
                    GuruId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NIP = table.Column<int>(type: "int", nullable: false),
                    JenisKelamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempatLahir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TanggalLahir = table.Column<DateOnly>(type: "date", nullable: false),
                    BidangEkstrakurikuler = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gurus", x => x.GuruId);
                    table.ForeignKey(
                        name: "FK_Gurus_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Siswas",
                columns: table => new
                {
                    SiswaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NIS = table.Column<int>(type: "int", nullable: false),
                    Kelas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JenisKelamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempatLahir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TanggalLahir = table.Column<DateOnly>(type: "date", nullable: false),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaAyah = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaIbu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siswas", x => x.SiswaId);
                    table.ForeignKey(
                        name: "FK_Siswas_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gurus_UserId",
                table: "Gurus",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Siswas_UserId",
                table: "Siswas",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gurus");

            migrationBuilder.DropTable(
                name: "Siswas");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
