using Code9.Domain.Interfaces;
using Code9.Domain.Models;
using MediatR;

namespace Code9.Domain.Handlers.Queries
{
    public record GetCinemaByIdQuery(Guid Id) : IRequest<Cinema>;

    public class GetCinemaByIdHandler : IRequestHandler<GetCinemaByIdQuery, Cinema>
    {
        public ICinemaRepository CinemaRepository { get; }

        public GetCinemaByIdHandler(ICinemaRepository cinemaRepository)
        {
            CinemaRepository = cinemaRepository;
        }

        public Task<Cinema> Handle(GetCinemaByIdQuery request, CancellationToken cancellationToken)
        {
            return CinemaRepository.GetCinemaById(request.Id);
        }
    }
}
