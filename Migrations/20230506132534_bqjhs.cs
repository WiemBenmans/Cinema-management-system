using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinema.Migrations
{
    /// <inheritdoc />
    public partial class bqjhs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservationDTOs_positionDTOs_positionresidPos",
                table: "reservationDTOs");

            migrationBuilder.DropIndex(
                name: "IX_reservationDTOs_positionresidPos",
                table: "reservationDTOs");

            migrationBuilder.DropColumn(
                name: "positionresidPos",
                table: "reservationDTOs");

            migrationBuilder.RenameColumn(
                name: "positionID",
                table: "reservationDTOs",
                newName: "planificationID");

            migrationBuilder.CreateIndex(
                name: "IX_reservationDTOs_planificationID",
                table: "reservationDTOs",
                column: "planificationID");

            migrationBuilder.AddForeignKey(
                name: "FK_reservationDTOs_planifications_planificationID",
                table: "reservationDTOs",
                column: "planificationID",
                principalTable: "planifications",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservationDTOs_planifications_planificationID",
                table: "reservationDTOs");

            migrationBuilder.DropIndex(
                name: "IX_reservationDTOs_planificationID",
                table: "reservationDTOs");

            migrationBuilder.RenameColumn(
                name: "planificationID",
                table: "reservationDTOs",
                newName: "positionID");

            migrationBuilder.AddColumn<int>(
                name: "positionresidPos",
                table: "reservationDTOs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_reservationDTOs_positionresidPos",
                table: "reservationDTOs",
                column: "positionresidPos");

            migrationBuilder.AddForeignKey(
                name: "FK_reservationDTOs_positionDTOs_positionresidPos",
                table: "reservationDTOs",
                column: "positionresidPos",
                principalTable: "positionDTOs",
                principalColumn: "idPos");
        }
    }
}
