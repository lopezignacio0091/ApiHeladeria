using MediatR;
using Microsoft.AspNetCore.Mvc;
using Positano.ApiHost.Controllers;
using Positano.ApiModel;
using Positano.Application.CQRS;
using System.Linq;
using System.Threading.Tasks;

namespace ApiHeladeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasteController : BaseController
    {
        private readonly IMediator _mediator;

        public TasteController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser([FromQuery] GetAllTasteQuery.Query query)
        {
            var result = await _mediator.Send(query);

            ApiResponse response;
            if (!result.IsValid)
                response = ApiResponse.Create(result.Errors);
            else
                response = ApiResponse.Create(new
                {
                    listGustos = result.Tastes.Select(u => new TasteViewModel(u))
                },
                "Acceso autorizado");

            return Ok(response);
        }
    }
}
