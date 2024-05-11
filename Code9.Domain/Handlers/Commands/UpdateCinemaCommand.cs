using Code9.Domain.Interfaces;
using Code9.Domain.Models;
using MediatR;

namespace Code9.Domain.Handlers.Commands
{
    public record UpdateCinemaCommand(
        Guid Id,
        string City,
        string Name,
        string Street,
        int NumOfAuditoriums) : IRequest;

    public class UpdateCinemaHandler : IRequestHandler<UpdateCinemaCommand>
    {
        public ICinemaRepository CinemaRepository { get; }

        public UpdateCinemaHandler(ICinemaRepository cinemaRepository)
        {
            CinemaRepository = cinemaRepository;
        }

        public async Task Handle(UpdateCinemaCommand request, CancellationToken cancellationToken)
        {
            await CinemaRepository.UpdateCinema(new Cinema()
            {
                Id = request.Id,
                City = request.City,
                Name = request.Name,
                Street = request.Street,
                NumberOfAuditoriums = request.NumOfAuditoriums
            });
        }
    }
}
