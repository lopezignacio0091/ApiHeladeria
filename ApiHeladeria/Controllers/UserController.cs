
using Positano.Application.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Positano.ApiModel;
using Positano.Domain.Entities;
using Positano.ApiHost.Controllers;

namespace ApiHeladeria.ApiHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {

        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser([FromQuery] GetAllUserQuery.Query query)
        {
            var result = await _mediator.Send(query);

            ApiResponse response;
            if (!result.IsValid)
                response = ApiResponse.Create(result.Errors);
            else
                response = ApiResponse.Create(new
                {
                    listUserDTO = result.Users.Select(u => new UserViewModel(u))
                },
                "Acceso autorizado");

            return Ok(response);
        }

        [HttpGet("getByPhone")]
        public async Task<IActionResult> GetById([FromQuery] GetUserByPhoneQuery.Query query)
        {
            GetUserByPhoneQuery.Result task = await _mediator.Send(query);

            ApiResponse response;
            if (!task.IsValid)
                response = ApiResponse.Create(task.Errors.FirstOrDefault().error);
            else
                response = ApiResponse.Create(new
                {
                    user = UserViewModel.Complete(task.User)
                },
                  "Acceso autorizado");

            return Ok(response);
        }

        [HttpPost("deleteById")]
        public async Task<IActionResult> Delete([FromBody] DeleteUserCommand.Command command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand.Command command)
        {
            var result = await _mediator.Send(command);
            ApiResponse response;
            if (!result.IsValid)
                response = ApiResponse.Create(result.Errors.FirstOrDefault());
            else
                response = ApiResponse.Create(new
                {
                    user = new UserViewModel((User)(result.Result))
                },
                  "Acceso autorizado");

            return Ok(response);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit([FromBody] EditUserCommand.Command command)
        {
            var result = await _mediator.Send(command);

            ApiResponse response;
            if (!result.IsValid)
                response = ApiResponse.Create(result.Errors.FirstOrDefault());
            else
                response = ApiResponse.Create(new
                {
                    user = UserViewModel.Complete((User)(result.Result))
                },
                  "Acceso autorizado");

            return Ok(response);
        }
    }
}
