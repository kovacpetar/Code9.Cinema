using Code9.Domain.Models;

namespace Code9.Domain.Interfaces
{
    public interface ICinemaRepository
    {
        public Task<List<Cinema>> GetAllCinemas();
        Task<Cinema> AddCinema(Cinema cinema);
        Task UpdateCinema(Guid id, string name, string city, string street);
    }
}
