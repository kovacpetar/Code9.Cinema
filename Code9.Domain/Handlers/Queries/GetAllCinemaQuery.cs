using Code9.Domain.Interfaces;
using Code9.Domain.Models;
using MediatR;

namespace Code9.Domain.Handlers.Queries
{
    public record GetAllCinemaQuery : IRequest<List<Cinema>>;

    public class GetAllCinemaHandler : IRequestHandler<GetAllCinemaQuery, List<Cinema>>
    {
        private readonly ICinemaRepository cinemaRepository;

        public GetAllCinemaHandler(ICinemaRepository cinemaRepository)
        {
            this.cinemaRepository = cinemaRepository;
        }

        public async Task<List<Cinema>> Handle(GetAllCinemaQuery request, CancellationToken cancellationToken)
        {
            return await cinemaRepository.GetAllCinemas();
        }
    }

}
