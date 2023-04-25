using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Viajes.Migrations
{
    public partial class Sucurrsal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sucurrsales",
                columns: table => new
                {
                    IdSucurrsal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FSucurrsal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SUbicacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucurrsales", x => x.IdSucurrsal);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sucurrsales");
        }
    }
}
