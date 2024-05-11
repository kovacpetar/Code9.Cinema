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
            await _dbContext.SaveChangesAsync();

            return entityObject.Entity;
        }

        public async Task UpdateCinema(Cinema cinema)
        {
            _dbContext.Cinemas.Update(cinema);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCinema(Guid id)
        {
            var entity = _dbContext.Cinemas.FirstOrDefault(x => x.Id == id);
            _dbContext.Cinemas.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Cinema> GetCinemaById(Guid id)
        {
            var entity = await _dbContext.Cinemas.FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }
    }
}