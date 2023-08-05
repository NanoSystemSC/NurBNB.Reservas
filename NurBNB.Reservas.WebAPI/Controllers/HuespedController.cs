using MediatR;
using Microsoft.AspNetCore.Mvc;
using NurBNB.Reservas.Application.UserCases.Huesped.Command.CrearHuesped;

namespace NurBNB.Reservas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HuespedController : Controller
    {
        private readonly IMediator _mediator;

        public HuespedController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHuespued([FromBody] CrearHuespedCommand command)
        {
            var HuespedID = await _mediator.Send(command);

            return Ok(HuespedID);
            
        }
    }
}
