using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NurBNB.Reservas.Application.UserCases.Huesped.Command.CrearHuesped;
using NurBNB.Reservas.Application.UserCases.Huesped.Query.GetHuespuedList;
using Sentry;


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

		  SentrySdk.CaptureMessage("Sentry:Huesped creado exitosamente: " + HuespedID);

		  return Ok(HuespedID);

	   }

	   // [Authorize]
	   [HttpGet]
	   [Route("BuscarHuesped2")]


	   public async Task<IActionResult> SearchItems(string searchTerm = "")
	   {
		  var huespedes = await _mediator.Send(new GetHuespedListQuery()
		  {
			 SearchTerm = searchTerm
		  });

		  SentrySdk.CaptureMessage("Sentry: Busqueda de Huesped");

		  return Ok(huespedes);
	   }
    }
}
