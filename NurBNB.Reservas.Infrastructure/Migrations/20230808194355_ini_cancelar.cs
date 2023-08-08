using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NurBNB.Reservas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ini_cancelar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CancelarReserva",
                columns: table => new
                {
                    ID_CancelarReserva = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReservaID = table.Column<Guid>(type: "TEXT", nullable: false),
                    FechaCancelacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Aplica_Descuento = table.Column<bool>(type: "INTEGER", nullable: false),
                    Motivo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Porcentaje_Devolucion = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancelarReserva", x => x.ID_CancelarReserva);
                });

            migrationBuilder.CreateTable(
                name: "TipoCancelacion",
                columns: table => new
                {
                    ID_TipoCancelacion = table.Column<Guid>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Dia_Ini = table.Column<int>(type: "INTEGER", nullable: false),
                    Dia_Fin = table.Column<int>(type: "INTEGER", nullable: false),
                    Porcentaje_Devolucion = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCancelacion", x => x.ID_TipoCancelacion);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CancelarReserva");

            migrationBuilder.DropTable(
                name: "TipoCancelacion");
        }
    }
}
