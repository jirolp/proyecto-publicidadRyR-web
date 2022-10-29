using Microsoft.EntityFrameworkCore.Migrations;

namespace api_publicidadRyR.Migrations
{
    public partial class Inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Cliente_dni_clicodigocliente",
                table: "Venta");

            migrationBuilder.RenameColumn(
                name: "dni_clicodigocliente",
                table: "Venta",
                newName: "codigocliente1");

            migrationBuilder.RenameIndex(
                name: "IX_Venta_dni_clicodigocliente",
                table: "Venta",
                newName: "IX_Venta_codigocliente1");

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Cliente_codigocliente1",
                table: "Venta",
                column: "codigocliente1",
                principalTable: "Cliente",
                principalColumn: "codigocliente",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Cliente_codigocliente1",
                table: "Venta");

            migrationBuilder.RenameColumn(
                name: "codigocliente1",
                table: "Venta",
                newName: "dni_clicodigocliente");

            migrationBuilder.RenameIndex(
                name: "IX_Venta_codigocliente1",
                table: "Venta",
                newName: "IX_Venta_dni_clicodigocliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Cliente_dni_clicodigocliente",
                table: "Venta",
                column: "dni_clicodigocliente",
                principalTable: "Cliente",
                principalColumn: "codigocliente",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
