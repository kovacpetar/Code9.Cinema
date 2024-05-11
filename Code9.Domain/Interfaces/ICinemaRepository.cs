using Code9.Domain.Models;

namespace Code9.Domain.Interfaces
{
    public interface ICinemaRepository
    {
        public Task<List<Cinema>> GetAllCinemas();
        public Task<Cinema> GetCinemaById(Guid id);
        Task<Cinema> AddCinema(Cinema cinema);
        Task UpdateCinema(Cinema cinema);
        Task DeleteCinema(Guid id);
    }
}
