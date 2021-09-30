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
    public class OrderController : BaseController
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand.Command command)
        {
            var result = await _mediator.Send(command);
            ApiResponse response;
            if (!result.IsValid)
                response = ApiResponse.Create(result.Errors.FirstOrDefault());
            else
                response = ApiResponse.Create(new
                {
                    order = new OrderViewModel((Order)(result.Result)),
                },
                  "");

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrder([FromQuery] GetAllOrderQuery.Query query)
        {
            var result = await _mediator.Send(query);

            ApiResponse response;
            if (!result.IsValid)
                response = ApiResponse.Create(result.Errors);
            else
                response = ApiResponse.Create(new
                {
                    listOrders = result.Orders.Select(u => new OrderViewModel(u))
                },
                "Acceso autorizado");

            return Ok(response);
        }

        [HttpGet("getDate")]
        public async Task<IActionResult> GetAllOrderDate([FromQuery] GetAllOrderDateQuery.Query query)
        {
            var result = await _mediator.Send(query);

            ApiResponse response;
            if (!result.IsValid)
                response = ApiResponse.Create(result.Errors);
            else
                response = ApiResponse.Create(new
                {
                    listOrders = result.Orders.Select(u => new OrderViewModel(u))
                },
                "Acceso autorizado");

            return Ok(response);
        }


        [HttpPost("UpdateStatus")]
        public async Task<IActionResult> EditStatus([FromBody] EditStatusOrderCommand.Command command)
        {
            var result = await _mediator.Send(command);
            ApiResponse response;
            if (!result.IsValid)
                response = ApiResponse.Create(result.Errors.FirstOrDefault());
            else
                response = ApiResponse.Create(new
                {
                    order = new OrderViewModel((Order)(result.Result)),
                },
                  "");

            return Ok(response);
        }
    }
}
