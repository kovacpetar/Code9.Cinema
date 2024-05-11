﻿using Code9.API.Models;
using Code9.Domain.Handlers.Commands;
using Code9.Domain.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Code9.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IResult> GetAll()
        {
            return Results.Ok(await mediator.Send(new GetAllCinemaQuery()));
        }

        [HttpPost]
        public async Task<IResult> CreateCinema([FromBody] AddCinemaRequest request)
        {
            var command = new AddCinemaCommand(request.City, request.Name, request.Street, request.NumOfAuditoriums);
            return Results.Ok(await mediator.Send(command));
        }

        [HttpPut]
        public async Task<IResult> UpdateCinema([AsParameters] Guid Id, [FromBody] UpdateCinemaRequest request)
        {
            var command = new UpdateCinemaCommand(Id, request.City, request.Name, request.Street, request.NumOfAuditoriums);
            await mediator.Send(command);
            return Results.NoContent();
        }
    }
}
