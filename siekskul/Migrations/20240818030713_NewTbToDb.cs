using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace siekskul.Migrations
{
    /// <inheritdoc />
    public partial class NewTbToDb : Migration
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

            migrationBuilder.DropColumn(
                name: "About",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TanggalLahir",
                table: "Siswas",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TanggalLahir",
                table: "Gurus",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Siswas_UserId",
                table: "Siswas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Gurus_UserId",
                table: "Gurus",
                column: "UserId");
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

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "TanggalLahir",
                table: "Siswas",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "TanggalLahir",
                table: "Gurus",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
    }
}
