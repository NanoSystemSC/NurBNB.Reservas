using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NurBNB.Reservas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class struct_PropiedadEstado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "propiedad",
                columns: table => new
                {
                    propiedadID = table.Column<Guid>(type: "TEXT", nullable: false),
                    ID_Propietario = table.Column<string>(type: "TEXT", nullable: false),
                    titulo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    detalle = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    ubicacion = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    estado = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_propiedad", x => x.propiedadID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "propiedad");
        }
    }
}
