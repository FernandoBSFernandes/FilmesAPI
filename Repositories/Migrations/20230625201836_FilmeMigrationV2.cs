using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class FilmeMigrationV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "duracao",
                table: "filme",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldRowVersion: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "duracao",
                table: "filme",
                type: "datetime2",
                rowVersion: true,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
