using Code9.Domain.Interfaces;
using Code9.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Code9.Infrastructure.Repositories
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly CinemaDbContext _dbContext;

        public CinemaRepository(CinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Cinema>> GetAllCinemas()
        {
            return await _dbContext.Cinemas.ToListAsync();
        }

        public async Task<Cinema> AddCinema(Cinema cinema)
        {
            var entityObject = await _dbContext.Cinemas.AddAsync(cinema);
            return entityObject.Entity;
        }

        public async Task UpdateCinema(Guid id, string name, string city, string street)
        {
            var cinema = await _dbContext.Cinemas.FirstOrDefaultAsync(x => x.Id == id);

            if (cinema is null) throw new ArgumentNullException($"Cinema with id: {id} could not be found.");

            cinema.Name = name;
            cinema.Street = street;
            cinema.City = city;

            await _dbContext.SaveChangesAsync();
        }
    }
}