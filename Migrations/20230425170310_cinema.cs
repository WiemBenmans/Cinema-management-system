using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinema.Migrations
{
    /// <inheritdoc />
    public partial class cinema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Date",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Date", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "positionDTOs",
                columns: table => new
                {
                    idPos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_positionDTOs", x => x.idPos);
                });

            migrationBuilder.CreateTable(
                name: "salleDTOs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombrePlaces = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salleDTOs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "reservationDTOs",
                columns: table => new
                {
                    idRéservation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientid = table.Column<int>(type: "int", nullable: false),
                    positionidPos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservationDTOs", x => x.idRéservation);
                    table.ForeignKey(
                        name: "FK_reservationDTOs_clients_clientid",
                        column: x => x.clientid,
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservationDTOs_positionDTOs_positionidPos",
                        column: x => x.positionidPos,
                        principalTable: "positionDTOs",
                        principalColumn: "idPos",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "planifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmidFilm = table.Column<int>(type: "int", nullable: false),
                    Salleid = table.Column<int>(type: "int", nullable: false),
                    DateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_planifications", x => x.id);
                    table.ForeignKey(
                        name: "FK_planifications_Date_DateId",
                        column: x => x.DateId,
                        principalTable: "Date",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_planifications_FilmDTOs_FilmidFilm",
                        column: x => x.FilmidFilm,
                        principalTable: "FilmDTOs",
                        principalColumn: "idFilm",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_planifications_salleDTOs_Salleid",
                        column: x => x.Salleid,
                        principalTable: "salleDTOs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_planifications_DateId",
                table: "planifications",
                column: "DateId");

            migrationBuilder.CreateIndex(
                name: "IX_planifications_FilmidFilm",
                table: "planifications",
                column: "FilmidFilm");

            migrationBuilder.CreateIndex(
                name: "IX_planifications_Salleid",
                table: "planifications",
                column: "Salleid");

            migrationBuilder.CreateIndex(
                name: "IX_reservationDTOs_clientid",
                table: "reservationDTOs",
                column: "clientid");

            migrationBuilder.CreateIndex(
                name: "IX_reservationDTOs_positionidPos",
                table: "reservationDTOs",
                column: "positionidPos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "planifications");

            migrationBuilder.DropTable(
                name: "reservationDTOs");

            migrationBuilder.DropTable(
                name: "Date");

            migrationBuilder.DropTable(
                name: "salleDTOs");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "positionDTOs");
        }
    }
}
