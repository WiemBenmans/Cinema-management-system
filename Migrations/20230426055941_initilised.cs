using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinema.Migrations
{
    /// <inheritdoc />
    public partial class initilised : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalleId",
                table: "positionDTOs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "colonne",
                table: "positionDTOs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ligne",
                table: "positionDTOs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_positionDTOs_SalleId",
                table: "positionDTOs",
                column: "SalleId");

            migrationBuilder.AddForeignKey(
                name: "FK_positionDTOs_salleDTOs_SalleId",
                table: "positionDTOs",
                column: "SalleId",
                principalTable: "salleDTOs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_positionDTOs_salleDTOs_SalleId",
                table: "positionDTOs");

            migrationBuilder.DropIndex(
                name: "IX_positionDTOs_SalleId",
                table: "positionDTOs");

            migrationBuilder.DropColumn(
                name: "SalleId",
                table: "positionDTOs");

            migrationBuilder.DropColumn(
                name: "colonne",
                table: "positionDTOs");

            migrationBuilder.DropColumn(
                name: "ligne",
                table: "positionDTOs");
        }
    }
}
