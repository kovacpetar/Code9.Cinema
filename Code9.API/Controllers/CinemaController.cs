using Code9.Domain.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Code9.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController(IMediator mediator) : ControllerBase
    {
        [HttpGet()]
        public async Task<IResult> GetAll()
        {
            return Results.Ok(await mediator.Send(new GetAllCinemaQuery()));
        }
    }
}
