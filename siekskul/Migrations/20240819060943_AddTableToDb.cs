using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace siekskul.Migrations
{
    /// <inheritdoc />
    public partial class AddTableToDb : Migration
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
                    NIP = table.Column<int>(type: "int", nullable: true),
                    JenisKelamin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempatLahir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalLahir = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BidangEkstrakurikuler = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    NIS = table.Column<int>(type: "int", nullable: true),
                    Kelas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JenisKelamin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempatLahir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalLahir = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaAyah = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaIbu = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "Ekstrakurikuler",
                columns: table => new
                {
                    EkstrakurikulerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deskripsi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuruId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ekstrakurikuler", x => x.EkstrakurikulerId);
                    table.ForeignKey(
                        name: "FK_Ekstrakurikuler_Gurus_GuruId",
                        column: x => x.GuruId,
                        principalTable: "Gurus",
                        principalColumn: "GuruId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JadwalEkstrakurikuler",
                columns: table => new
                {
                    JadwalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EkstrakurikulerId = table.Column<int>(type: "int", nullable: false),
                    Hari = table.Column<int>(type: "int", nullable: false),
                    WaktuMulai = table.Column<TimeSpan>(type: "time", nullable: false),
                    WaktuSelesai = table.Column<TimeSpan>(type: "time", nullable: false),
                    Lokasi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JadwalEkstrakurikuler", x => x.JadwalId);
                    table.ForeignKey(
                        name: "FK_JadwalEkstrakurikuler_Ekstrakurikuler_EkstrakurikulerId",
                        column: x => x.EkstrakurikulerId,
                        principalTable: "Ekstrakurikuler",
                        principalColumn: "EkstrakurikulerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PendaftaranEkstrakurikuler",
                columns: table => new
                {
                    PendaftaranId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiswaId = table.Column<int>(type: "int", nullable: false),
                    EkstrakurikulerId = table.Column<int>(type: "int", nullable: false),
                    TanggalPendaftaran = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PendaftaranEkstrakurikuler", x => x.PendaftaranId);
                    table.ForeignKey(
                        name: "FK_PendaftaranEkstrakurikuler_Ekstrakurikuler_EkstrakurikulerId",
                        column: x => x.EkstrakurikulerId,
                        principalTable: "Ekstrakurikuler",
                        principalColumn: "EkstrakurikulerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PendaftaranEkstrakurikuler_Siswas_SiswaId",
                        column: x => x.SiswaId,
                        principalTable: "Siswas",
                        principalColumn: "SiswaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ekstrakurikuler_GuruId",
                table: "Ekstrakurikuler",
                column: "GuruId");

            migrationBuilder.CreateIndex(
                name: "IX_Gurus_UserId",
                table: "Gurus",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JadwalEkstrakurikuler_EkstrakurikulerId",
                table: "JadwalEkstrakurikuler",
                column: "EkstrakurikulerId");

            migrationBuilder.CreateIndex(
                name: "IX_PendaftaranEkstrakurikuler_EkstrakurikulerId",
                table: "PendaftaranEkstrakurikuler",
                column: "EkstrakurikulerId");

            migrationBuilder.CreateIndex(
                name: "IX_PendaftaranEkstrakurikuler_SiswaId",
                table: "PendaftaranEkstrakurikuler",
                column: "SiswaId");

            migrationBuilder.CreateIndex(
                name: "IX_Siswas_UserId",
                table: "Siswas",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JadwalEkstrakurikuler");

            migrationBuilder.DropTable(
                name: "PendaftaranEkstrakurikuler");

            migrationBuilder.DropTable(
                name: "Ekstrakurikuler");

            migrationBuilder.DropTable(
                name: "Siswas");

            migrationBuilder.DropTable(
                name: "Gurus");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
