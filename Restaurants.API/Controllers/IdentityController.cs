using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Users.Commands;

namespace Restaurants.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController(IMediator mediator) : ControllerBase
    {
        [HttpPatch("user")]

        public async Task<ActionResult> UpdateUserDetails(UpdateUseDetailsCommand updateUseDetailsCommand)
        {
            await mediator.Send(updateUseDetailsCommand);
            return NoContent();
        }
    }
}
