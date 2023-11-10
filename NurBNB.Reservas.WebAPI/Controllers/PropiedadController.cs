using MediatR;
using Microsoft.AspNetCore.Mvc;
using NurBNB.Reservas.Application.UserCases.Huesped.Query.GetHuespuedList;
using NurBNB.Reservas.Application.UserCases.Propiedad.Command.CrearPropiedad;
using NurBNB.Reservas.Application.UserCases.Propiedad.Query.GetPropiedadDisponiblesList;
using NurBNB.Reservas.Domain.Model.Estados;

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

            return Ok(Propiedades);
        }
    }
}
