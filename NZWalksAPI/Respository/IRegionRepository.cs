using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Respository
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync(string? filterOn,string? filterQuery, string? sortBy, [FromQuery] bool isAsc, int pageNumber, int pageSize);

        Task<Region> GetbyIdAsync(Guid Id);

        Task<Region> AddRegion(Region region);

        Task<Region?> UpdateRegionAsync(Guid id,Region region);

        Task<Region?> DeleteRegionAsync(Guid id);
    }
}
