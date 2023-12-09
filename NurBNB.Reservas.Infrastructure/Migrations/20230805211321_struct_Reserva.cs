using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NurBNB.Reservas.Infrastructure.Migrations
{
    [ExcludeFromCodeCoverage]
    /// <inheritdoc />
    public partial class structReserva : Migration
    {
	   /// <inheritdoc />
	   protected override void Up(MigrationBuilder migrationBuilder)
	   {
		  migrationBuilder.CreateTable(
			  name: "Reserva",
			  columns: table => new
			  {
				 ID_Reserva = table.Column<Guid>(type: "TEXT", nullable: false),
				 Huesped_ID = table.Column<Guid>(type: "TEXT", nullable: false),
				 Propiedad_ID = table.Column<Guid>(type: "TEXT", nullable: false),
				 FechaCheckin = table.Column<DateTime>(type: "TEXT", nullable: false),
				 FechaCheckOut = table.Column<DateTime>(type: "TEXT", nullable: false),
				 FechaRegistro = table.Column<DateTime>(type: "TEXT", nullable: false),
				 Motivo = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
				 Estado = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
			  },
			  constraints: table =>
			  {
				 table.PrimaryKey("PK_Reserva", x => x.ID_Reserva);
			  });
	   }

	   /// <inheritdoc />
	   protected override void Down(MigrationBuilder migrationBuilder)
	   {
		  migrationBuilder.DropTable(
			  name: "Reserva");
	   }
    }
}
