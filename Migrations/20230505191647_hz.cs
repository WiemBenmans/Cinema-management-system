using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinema.Migrations
{
    /// <inheritdoc />
    public partial class hz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservationDTOs_clients_clientid",
                table: "reservationDTOs");

            migrationBuilder.DropForeignKey(
                name: "FK_reservationDTOs_positionDTOs_positionidPos",
                table: "reservationDTOs");

            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clients",
                table: "clients");

            migrationBuilder.RenameTable(
                name: "clients",
                newName: "userDTO");

            migrationBuilder.RenameColumn(
                name: "clientid",
                table: "reservationDTOs",
                newName: "clientID");

            migrationBuilder.RenameColumn(
                name: "positionidPos",
                table: "reservationDTOs",
                newName: "positionresidPos");

            migrationBuilder.RenameIndex(
                name: "IX_reservationDTOs_clientid",
                table: "reservationDTOs",
                newName: "IX_reservationDTOs_clientID");

            migrationBuilder.RenameIndex(
                name: "IX_reservationDTOs_positionidPos",
                table: "reservationDTOs",
                newName: "IX_reservationDTOs_positionresidPos");

            migrationBuilder.AddColumn<int>(
                name: "positionID",
                table: "reservationDTOs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "userDTO",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userDTO",
                table: "userDTO",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_reservationDTOs_positionDTOs_positionresidPos",
                table: "reservationDTOs",
                column: "positionresidPos",
                principalTable: "positionDTOs",
                principalColumn: "idPos",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservationDTOs_userDTO_clientID",
                table: "reservationDTOs",
                column: "clientID",
                principalTable: "userDTO",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservationDTOs_positionDTOs_positionresidPos",
                table: "reservationDTOs");

            migrationBuilder.DropForeignKey(
                name: "FK_reservationDTOs_userDTO_clientID",
                table: "reservationDTOs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userDTO",
                table: "userDTO");

            migrationBuilder.DropColumn(
                name: "positionID",
                table: "reservationDTOs");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "userDTO");

            migrationBuilder.RenameTable(
                name: "userDTO",
                newName: "clients");

            migrationBuilder.RenameColumn(
                name: "clientID",
                table: "reservationDTOs",
                newName: "clientid");

            migrationBuilder.RenameColumn(
                name: "positionresidPos",
                table: "reservationDTOs",
                newName: "positionidPos");

            migrationBuilder.RenameIndex(
                name: "IX_reservationDTOs_clientID",
                table: "reservationDTOs",
                newName: "IX_reservationDTOs_clientid");

            migrationBuilder.RenameIndex(
                name: "IX_reservationDTOs_positionresidPos",
                table: "reservationDTOs",
                newName: "IX_reservationDTOs_positionidPos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clients",
                table: "clients",
                column: "id");

            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_reservationDTOs_clients_clientid",
                table: "reservationDTOs",
                column: "clientid",
                principalTable: "clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservationDTOs_positionDTOs_positionidPos",
                table: "reservationDTOs",
                column: "positionidPos",
                principalTable: "positionDTOs",
                principalColumn: "idPos",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
