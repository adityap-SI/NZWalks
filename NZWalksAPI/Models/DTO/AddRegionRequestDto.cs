using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(10, ErrorMessage = "Minimum Length should be 10")]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
