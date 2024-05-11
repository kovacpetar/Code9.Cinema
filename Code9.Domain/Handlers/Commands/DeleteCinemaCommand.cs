using Code9.Domain.Interfaces;
using MediatR;

namespace Code9.Domain.Handlers.Commands
{
    public record DeleteCinemaCommand(Guid Id) : IRequest;

    public class DeleteCinemaHandler : IRequestHandler<DeleteCinemaCommand>
    {
        public ICinemaRepository CinemaRepository { get; }


        public DeleteCinemaHandler(ICinemaRepository cinemaRepository)
        {
            CinemaRepository = cinemaRepository;
        }

        public Task Handle(DeleteCinemaCommand request, CancellationToken cancellationToken)
        {
            return CinemaRepository.DeleteCinema(request.Id);
        }
    }
}
