using MediatR;
using Microsoft.AspNetCore.Mvc;
using Positano.ApiHost.Controllers;
using Positano.ApiModel;
using Positano.Application.CQRS;
using Positano.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiHeladeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : BaseController
    {

        private readonly IMediator _mediator;

        public PurchaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPurchase([FromQuery] GetAllPurchaseQuery.Query query)
        {
            var result = await _mediator.Send(query);

            ApiResponse response;
            if (!result.IsValid)
                response = ApiResponse.Create(result.Errors);
            else
                response = ApiResponse.Create(new
                {
                    listPurchaseDTO = result.Purchases.Select(u => new PurchaseViewModel(u,false))
                },
                "Acceso autorizado");

            return Ok(response);
        }



        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePurchaseCommand.Command command)
        {
            var result = await _mediator.Send(command);
            ApiResponse response;
            if (!result.IsValid)
                response = ApiResponse.Create(result.Errors.FirstOrDefault());
            else
                response = ApiResponse.Create(new
                {
                    purchase = new PurchaseViewModel((Purchase)(result.Result)),
                },
                  "");

            return Ok(response);
        }

    }
}
