using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NurBNB.Reservas.Infrastructure.Migrations
{
    [ExcludeFromCodeCoverage]
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
                    ID_Propiedad = table.Column<Guid>(type: "TEXT", nullable: false),
                    Propietario_ID = table.Column<string>(type: "TEXT", nullable: false),
                    titulo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    detalle = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    ubicacion = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    estado = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_propiedad", x => x.ID_Propiedad);
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
