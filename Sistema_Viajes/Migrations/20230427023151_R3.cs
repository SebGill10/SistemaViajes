using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Viajes.Migrations
{
    public partial class R3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistroViajes",
                columns: table => new
                {
                    IdRegistroViaje = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    SucursalId = table.Column<int>(type: "int", nullable: false),
                    TransportistaId = table.Column<int>(type: "int", nullable: false),
                    FechaViaje = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroViajes", x => x.IdRegistroViaje);
                    table.ForeignKey(
                        name: "FK_RegistroViajes_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "IdSucursal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistroViajes_Transportistas_TransportistaId",
                        column: x => x.TransportistaId,
                        principalTable: "Transportistas",
                        principalColumn: "IdTransportista",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistroViajeColaboradores",
                columns: table => new
                {
                    ViajeId = table.Column<int>(type: "int", nullable: false),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    RegistroViajeIdRegistroViaje = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroViajeColaboradores", x => new { x.ColaboradorId, x.ViajeId });
                    table.ForeignKey(
                        name: "FK_RegistroViajeColaboradores_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "IdColaborador",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistroViajeColaboradores_RegistroViajes_RegistroViajeIdRegistroViaje",
                        column: x => x.RegistroViajeIdRegistroViaje,
                        principalTable: "RegistroViajes",
                        principalColumn: "IdRegistroViaje",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistroViajeColaboradores_RegistroViajeIdRegistroViaje",
                table: "RegistroViajeColaboradores",
                column: "RegistroViajeIdRegistroViaje");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroViajes_SucursalId",
                table: "RegistroViajes",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroViajes_TransportistaId",
                table: "RegistroViajes",
                column: "TransportistaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroViajeColaboradores");

            migrationBuilder.DropTable(
                name: "RegistroViajes");
        }
    }
}
