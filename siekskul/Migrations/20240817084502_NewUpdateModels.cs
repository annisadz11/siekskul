using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace siekskul.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Siswas_UserId",
                table: "Siswas");

            migrationBuilder.DropIndex(
                name: "IX_Gurus_UserId",
                table: "Gurus");

            migrationBuilder.CreateIndex(
                name: "IX_Siswas_UserId",
                table: "Siswas",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gurus_UserId",
                table: "Gurus",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Siswas_UserId",
                table: "Siswas");

            migrationBuilder.DropIndex(
                name: "IX_Gurus_UserId",
                table: "Gurus");

            migrationBuilder.CreateIndex(
                name: "IX_Siswas_UserId",
                table: "Siswas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Gurus_UserId",
                table: "Gurus",
                column: "UserId");
        }
    }
}
