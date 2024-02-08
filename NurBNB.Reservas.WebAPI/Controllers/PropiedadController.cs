using MediatR;
using Microsoft.AspNetCore.Mvc;
using NurBNB.Reservas.Application.UserCases.Propiedad.Command.CrearPropiedad;
using NurBNB.Reservas.Application.UserCases.Propiedad.Query.GetListofPropiedades;
using NurBNB.Reservas.Application.UserCases.Propiedad.Query.GetPropiedadDisponiblesList;
using NurBNB.Reservas.Domain.Model.Estados;
using Sentry;

namespace NurBNB.Reservas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropiedadController : Controller
    {
	   readonly IMediator _mediator;

	   public PropiedadController(IMediator mediator)
	   {
		  _mediator = mediator;
	   }


	   [HttpPost]
	   public async Task<IActionResult> CreatePropiedad([FromBody] CrearPropiedadCommand command)
	   {
		  var PropiedadID = await _mediator.Send(command);

		  SentrySdk.CaptureMessage("Sentry: Crear Propiedad exitosa");

		  return Ok(PropiedadID);
	   }

	   [HttpGet]
	   [Route("PropiedadesDisponibles")]
	   public async Task<IActionResult> SearchItems(TipoEstadoReserva tipoEstadoReserva)
	   {
		  var Propiedades = await _mediator.Send(new GetPropiedadDisponiblesQuery()
		  {
			 estadoReserva = tipoEstadoReserva
		  });

		  SentrySdk.CaptureMessage("Sentry: Busqueda de Propiedad exitosa");

		  return Ok(Propiedades);
	   }

	   [HttpGet]
	   [Route("ListaPropiedades")]
	   public async Task<IActionResult> ListaPropiedades(TipoEstadoReserva tipoEstadoReserva)
	   {
		  var Propiedades = await _mediator.Send(new GetListofPropiedadesQuery()
		  {
			 estadoReserva = tipoEstadoReserva
		  });

		  SentrySdk.CaptureMessage("Sentry: Busqueda de Propiedad exitosa");

		  return Ok(Propiedades);
	   }
    }
}
