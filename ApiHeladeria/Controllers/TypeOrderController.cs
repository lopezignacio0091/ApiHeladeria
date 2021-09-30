using MediatR;
using Microsoft.AspNetCore.Mvc;
using Positano.ApiHost.Controllers;
using Positano.ApiModel;
using Positano.Application.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiHeladeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOrderController : BaseController
    {
        private readonly IMediator _mediator;

        public TypeOrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser([FromQuery] GetAllTypeOrderQuery.Query query)
        {
            var result = await _mediator.Send(query);

            ApiResponse response;
            if (!result.IsValid)
                response = ApiResponse.Create(result.Errors);
            else
                response = ApiResponse.Create(new
                {
                    listTypeOrders= result.TypeOrders.Select(u => new TypeOrderViewModel(u))
                },
                "Acceso autorizado");

            return Ok(response);
        }

    }
}
