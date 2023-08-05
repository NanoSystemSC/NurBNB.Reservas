using MediatR;
using Microsoft.AspNetCore.Mvc;
using NurBNB.Reservas.Application.UserCases.Propiedad.Command.CrearPropiedad;

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
    }
}
