using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Respository;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IWalkRepository walkRepository;
        public Guid Id;

        public WalksController(NZWalksDbContext dbContext, IWalkRepository walkRepository)
        {
            this.dbContext = dbContext;
            this.walkRepository = walkRepository;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            return Ok(await walkRepository.GetAllAsync());
        }

    }
}
