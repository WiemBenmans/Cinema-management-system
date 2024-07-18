using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinema.Migrations
{
    /// <inheritdoc />
    public partial class initiliseffjg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_planifications_FilmDTOs_FilmidFilm",
                table: "planifications");

            migrationBuilder.DropForeignKey(
                name: "FK_planifications_salleDTOs_Salleid",
                table: "planifications");

            migrationBuilder.DropIndex(
                name: "IX_planifications_FilmidFilm",
                table: "planifications");

            migrationBuilder.RenameColumn(
                name: "Salleid",
                table: "planifications",
                newName: "SalleId");

            migrationBuilder.RenameColumn(
                name: "FilmidFilm",
                table: "planifications",
                newName: "IdDate");

            migrationBuilder.RenameIndex(
                name: "IX_planifications_Salleid",
                table: "planifications",
                newName: "IX_planifications_SalleId");

            migrationBuilder.AddColumn<int>(
                name: "FilmId",
                table: "planifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_planifications_FilmId",
                table: "planifications",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_planifications_FilmDTOs_FilmId",
                table: "planifications",
                column: "FilmId",
                principalTable: "FilmDTOs",
                principalColumn: "idFilm",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_planifications_salleDTOs_SalleId",
                table: "planifications",
                column: "SalleId",
                principalTable: "salleDTOs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_planifications_FilmDTOs_FilmId",
                table: "planifications");

            migrationBuilder.DropForeignKey(
                name: "FK_planifications_salleDTOs_SalleId",
                table: "planifications");

            migrationBuilder.DropIndex(
                name: "IX_planifications_FilmId",
                table: "planifications");

            migrationBuilder.DropColumn(
                name: "FilmId",
                table: "planifications");

            migrationBuilder.RenameColumn(
                name: "SalleId",
                table: "planifications",
                newName: "Salleid");

            migrationBuilder.RenameColumn(
                name: "IdDate",
                table: "planifications",
                newName: "FilmidFilm");

            migrationBuilder.RenameIndex(
                name: "IX_planifications_SalleId",
                table: "planifications",
                newName: "IX_planifications_Salleid");

            migrationBuilder.CreateIndex(
                name: "IX_planifications_FilmidFilm",
                table: "planifications",
                column: "FilmidFilm");

            migrationBuilder.AddForeignKey(
                name: "FK_planifications_FilmDTOs_FilmidFilm",
                table: "planifications",
                column: "FilmidFilm",
                principalTable: "FilmDTOs",
                principalColumn: "idFilm",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_planifications_salleDTOs_Salleid",
                table: "planifications",
                column: "Salleid",
                principalTable: "salleDTOs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
