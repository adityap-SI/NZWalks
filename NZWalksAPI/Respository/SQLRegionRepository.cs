using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Respository
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SQLRegionRepository(NZWalksDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public async Task<Region> AddRegion(Region region)
        {
            
            dbContext.Regions.Add(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteRegionAsync(Guid id)
        {
            var exists = dbContext.Regions.FirstOrDefault(r => r.Id == id);

            if (exists != null)
            {
                return null;
            }

            dbContext.Regions.Remove(exists);
            await dbContext.SaveChangesAsync();
            return exists;
        }

        public async Task<List<Region>> GetAllAsync(string? filterOn = null,string? filterQuery = null,
            string? sortBy = null, bool isAsc = true, int pageNumber = 1, int pageSize = 100)
        {
            var regions = dbContext.Regions.AsQueryable();

            if(string.IsNullOrEmpty(filterOn) == false && string.IsNullOrEmpty(filterQuery)==false) {
                if (filterOn.Contains("Name", StringComparison.OrdinalIgnoreCase))
                {
                    regions = regions.Where(x => x.Name.Contains(filterQuery));
                }
            }

            // sort

            if(string.IsNullOrEmpty(sortBy) == false)
            {
                if (sortBy.Contains("Name", StringComparison.OrdinalIgnoreCase))
                {
                    regions = isAsc ? regions.OrderBy(x => x.Name) : regions.OrderByDescending(x => x.Name);
                }
            }
            
            var skipResults = (pageNumber - 1)  * pageSize;



            return await regions.Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<Region> GetbyIdAsync(Guid Id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == Id);
        }

        public async Task<Region?> UpdateRegionAsync(Guid id,Region region)
        {
            var exists = dbContext.Regions.FirstOrDefault(r => r.Id == id);

            if (exists == null)
            {
                return null;
            }

            exists.Name = region.Name;
            exists.Code = region.Code;
            exists.RegionImageUrl = region.RegionImageUrl;

            dbContext.Regions.Update(exists);
            await dbContext.SaveChangesAsync();
            return exists;
        }
    }
}
