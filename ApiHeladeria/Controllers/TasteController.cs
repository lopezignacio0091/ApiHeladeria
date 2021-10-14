using MediatR;
using Microsoft.AspNetCore.Mvc;
using Positano.ApiHost.Controllers;
using Positano.ApiModel;
using Positano.Application.CQRS;
using Positano.Domain.Entities;
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


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTasteCommand.Command command)
        {
            var result = await _mediator.Send(command);
            ApiResponse response;
            if (!result.IsValid)
                response = ApiResponse.Create(result.Errors.FirstOrDefault());
            else
                response = ApiResponse.Create(new
                {
                    purchase = new TasteViewModel((Taste)(result.Result)),
                },
                  "");

            return Ok(response);
        }
    }
}
