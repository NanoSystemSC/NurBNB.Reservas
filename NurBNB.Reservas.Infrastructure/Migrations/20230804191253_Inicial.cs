using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NurBNB.Reservas.Infrastructure.Migrations
{
    [ExcludeFromCodeCoverage]
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
	   /// <inheritdoc />
	   protected override void Up(MigrationBuilder migrationBuilder)
	   {
		  migrationBuilder.CreateTable(
			  name: "huesped",
			  columns: table => new
			  {
				 huespedID = table.Column<Guid>(type: "TEXT", nullable: false),
				 nombres = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
				 apellidos = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
				 telefono = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
				 nrodoc = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
				 email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
				 calle = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
				 ciudad = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
				 pais = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
				 codigo_postal = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false)
			  },
			  constraints: table =>
			  {
				 table.PrimaryKey("PK_huesped", x => x.huespedID);
			  });
	   }

	   /// <inheritdoc />
	   protected override void Down(MigrationBuilder migrationBuilder)
	   {
		  migrationBuilder.DropTable(
			  name: "huesped");
	   }
    }
}
