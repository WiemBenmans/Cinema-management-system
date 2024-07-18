using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinema.Migrations
{
    /// <inheritdoc />
    public partial class hg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservationDTOs_positionDTOs_positionresidPos",
                table: "reservationDTOs");

            migrationBuilder.AlterColumn<int>(
                name: "positionresidPos",
                table: "reservationDTOs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_reservationDTOs_positionDTOs_positionresidPos",
                table: "reservationDTOs",
                column: "positionresidPos",
                principalTable: "positionDTOs",
                principalColumn: "idPos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservationDTOs_positionDTOs_positionresidPos",
                table: "reservationDTOs");

            migrationBuilder.AlterColumn<int>(
                name: "positionresidPos",
                table: "reservationDTOs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_reservationDTOs_positionDTOs_positionresidPos",
                table: "reservationDTOs",
                column: "positionresidPos",
                principalTable: "positionDTOs",
                principalColumn: "idPos",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
