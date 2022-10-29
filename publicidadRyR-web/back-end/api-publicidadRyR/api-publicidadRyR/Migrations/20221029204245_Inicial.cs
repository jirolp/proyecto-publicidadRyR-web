using Microsoft.EntityFrameworkCore.Migrations;

namespace api_publicidadRyR.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    codigocliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.codigocliente);
                });

            migrationBuilder.CreateTable(
                name: "Juguetes",
                columns: table => new
                {
                    id_prod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    precio_prod = table.Column<double>(type: "float", nullable: false),
                    cant_prod = table.Column<int>(type: "int", nullable: false),
                    nombre_prod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Juguetes", x => x.id_prod);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    codigo_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_user = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ape_user = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.codigo_user);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    codigo_venta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fech_venta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dni_clicodigocliente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.codigo_venta);
                    table.ForeignKey(
                        name: "FK_Venta_Cliente_dni_clicodigocliente",
                        column: x => x.dni_clicodigocliente,
                        principalTable: "Cliente",
                        principalColumn: "codigocliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Detalle_venta",
                columns: table => new
                {
                    id_detalle_venta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_ventacodigo_venta = table.Column<int>(type: "int", nullable: false),
                    id_prod1 = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_venta", x => x.id_detalle_venta);
                    table.ForeignKey(
                        name: "FK_Detalle_venta_Juguetes_id_prod1",
                        column: x => x.id_prod1,
                        principalTable: "Juguetes",
                        principalColumn: "id_prod",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detalle_venta_Venta_id_ventacodigo_venta",
                        column: x => x.id_ventacodigo_venta,
                        principalTable: "Venta",
                        principalColumn: "codigo_venta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_venta_id_prod1",
                table: "Detalle_venta",
                column: "id_prod1");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_venta_id_ventacodigo_venta",
                table: "Detalle_venta",
                column: "id_ventacodigo_venta");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_dni_clicodigocliente",
                table: "Venta",
                column: "dni_clicodigocliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle_venta");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Juguetes");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
