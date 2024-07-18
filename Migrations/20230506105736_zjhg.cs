using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinema.Migrations
{
    /// <inheritdoc />
    public partial class zjhg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_planifications_Date_DateId",
                table: "planifications");

            migrationBuilder.AlterColumn<int>(
                name: "IdDate",
                table: "planifications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DateId",
                table: "planifications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_planifications_Date_DateId",
                table: "planifications",
                column: "DateId",
                principalTable: "Date",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_planifications_Date_DateId",
                table: "planifications");

            migrationBuilder.AlterColumn<int>(
                name: "IdDate",
                table: "planifications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DateId",
                table: "planifications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_planifications_Date_DateId",
                table: "planifications",
                column: "DateId",
                principalTable: "Date",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
