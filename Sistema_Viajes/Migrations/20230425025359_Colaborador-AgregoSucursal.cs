using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Viajes.Migrations
{
    public partial class ColaboradorAgregoSucursal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SucurrsalId",
                table: "Colaboradores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_SucurrsalId",
                table: "Colaboradores",
                column: "SucurrsalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaboradores_Sucurrsales_SucurrsalId",
                table: "Colaboradores",
                column: "SucurrsalId",
                principalTable: "Sucurrsales",
                principalColumn: "IdSucurrsal",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradores_Sucurrsales_SucurrsalId",
                table: "Colaboradores");

            migrationBuilder.DropIndex(
                name: "IX_Colaboradores_SucurrsalId",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "SucurrsalId",
                table: "Colaboradores");
        }
    }
}
