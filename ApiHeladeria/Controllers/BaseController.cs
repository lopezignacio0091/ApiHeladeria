
using Microsoft.AspNetCore.Mvc;
using Positano.ApiModel;

namespace Positano.ApiHost.Controllers
{
    public class BaseController : ControllerBase
    {
        protected BadRequestObjectResult Fail(string message)
        {
            var response = new
            {
                message,
                status = ResponseStatus.Error.ToString()
            };

            return BadRequest(response);
        }

        protected BadRequestObjectResult Success(object value)
        {
            var response = new
            {
                status = ResponseStatus.Error
            };

            return BadRequest(response);
        }
    }
}
