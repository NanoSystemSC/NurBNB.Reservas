using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NurBNB.Reservas.Application.UserCases.Huesped.Command.CrearHuesped;
using NurBNB.Reservas.Application.UserCases.Huesped.Query.GetHuespuedList;

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
        [Route("CrearHuesped")]
        public async Task<IActionResult> CreateHuespued([FromBody] CrearHuespedCommand command)
        {
            var HuespedID = await _mediator.Send(command);

            return Ok(HuespedID);
            
        }

       // [Authorize]
        [HttpGet]
        [Route("BuscarHuesped")]
        public async Task<IActionResult> SearchItems(string searchTerm = "")
        {
            var huespedes = await _mediator.Send(new GetHuespedListQuery()
            {
                SearchTerm = searchTerm
            });

            return Ok(huespedes);
        }
    }
}
