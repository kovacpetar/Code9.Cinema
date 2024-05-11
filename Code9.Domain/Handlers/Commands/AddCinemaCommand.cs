using Code9.Domain.Interfaces;
using Code9.Domain.Models;
using MediatR;

namespace Code9.Domain.Handlers.Commands
{
    public record AddCinemaCommand(
        string City, 
        string Name, 
        string Street, 
        int NumOfAuditoriums) : IRequest<Cinema>;

    public class AddCinemaHandler : IRequestHandler<AddCinemaCommand, Cinema>
    {
        private readonly ICinemaRepository cinemaRepository;

        public AddCinemaHandler(ICinemaRepository cinemaRepository)
        {
            this.cinemaRepository = cinemaRepository;
        }

        public async Task<Cinema> Handle(AddCinemaCommand request, CancellationToken cancellationToken)
        {
            var cinemaDb = await cinemaRepository.AddCinema(new Cinema
            {
                City = request.City,
                Name = request.Name,
                Street = request.Street,
                NumberOfAuditoriums = request.NumOfAuditoriums
            });

            return cinemaDb;
        }
    }
}
