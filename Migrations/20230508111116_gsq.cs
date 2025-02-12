﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinema.Migrations
{
    /// <inheritdoc />
    public partial class gsq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_planifications_FilmDTOs_FilmId",
                table: "planifications");

            migrationBuilder.AlterColumn<int>(
                name: "FilmId",
                table: "planifications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "nom",
                table: "FilmDTOs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "categorie",
                table: "FilmDTOs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_planifications_FilmDTOs_FilmId",
                table: "planifications",
                column: "FilmId",
                principalTable: "FilmDTOs",
                principalColumn: "idFilm");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_planifications_FilmDTOs_FilmId",
                table: "planifications");

            migrationBuilder.AlterColumn<int>(
                name: "FilmId",
                table: "planifications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nom",
                table: "FilmDTOs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "categorie",
                table: "FilmDTOs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_planifications_FilmDTOs_FilmId",
                table: "planifications",
                column: "FilmId",
                principalTable: "FilmDTOs",
                principalColumn: "idFilm",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
