using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Respository
{
    public class SQLWalksRepository : IWalkRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SQLWalksRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Walks>> GetAllAsync()
        {
            return await dbContext.Walks.ToListAsync();
        }

    }
}
