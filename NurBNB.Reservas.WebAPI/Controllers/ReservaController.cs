using MediatR;
using Microsoft.AspNetCore.Mvc;
using NurBNB.Reservas.Application.UserCases.Propiedad.Query.GetPropiedadDisponiblesList;
using NurBNB.Reservas.Application.UserCases.Reserva.Command.CrearReserva;
using NurBNB.Reservas.Domain.Model.Estados;
using Sentry;

namespace NurBNB.Reservas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : Controller
    {
	   readonly IMediator _mediator;

	   public ReservaController(IMediator mediator)
	   {
		  _mediator = mediator;
	   }

	   [HttpPost]
	   public async Task<IActionResult> CreateReserva([FromBody] CrearReservaCommand command)
	   {
		  var ReservaID = await _mediator.Send(command);

		  SentrySdk.CaptureMessage("Sentry: Crear Reserva exitosa");

		  return Ok(ReservaID);
	   }

	   [HttpGet]
	   [Route("PropiedadesDisponibles")]
	   public async Task<IActionResult> SearchItems(TipoEstadoReserva tipoEstadoReserva)
	   {
		  var Propiedades = await _mediator.Send(new GetPropiedadDisponiblesQuery()
		  {
			 estadoReserva = tipoEstadoReserva
		  });

		  SentrySdk.CaptureMessage("Sentry: Busqueda de Reserva exitosa");

		  return Ok(Propiedades);
	   }
    }
}
