using MediatR;
using Microsoft.AspNetCore.Mvc;
using NurBNB.Reservas.Application.UserCases.CancelarReserva.Command.CrearReserva;
using NurBNB.Reservas.Application.UserCases.Reserva.Command.CrearReserva;

namespace NurBNB.Reservas.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CancelarReservaController : Controller
	{
		readonly IMediator _mediator;

		public CancelarReservaController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> CreateCancelarReserva([FromBody] CrearCancelacionCommand command)
		{
			var CancelacionID = await _mediator.Send(command);
			return Ok(CancelacionID);
		}
	}
}
