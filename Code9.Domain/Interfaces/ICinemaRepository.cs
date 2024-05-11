using Code9.Domain.Models;

namespace Code9.Domain.Interfaces
{
    public interface ICinemaRepository
    {
        public Task<List<Cinema>> GetAllCinemas();
        Task<Cinema> AddCinema(Cinema cinema);
        Task UpdateCinema(Cinema cinema);
    }
}
