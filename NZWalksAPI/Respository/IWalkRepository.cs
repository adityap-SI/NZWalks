using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Respository
{
    public interface IWalkRepository
    {
        Task<List<Walks>> GetAllAsync();
    }
}
