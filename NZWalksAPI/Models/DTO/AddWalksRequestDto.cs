﻿using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Models.DTO
{
    public class AddWalksRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LengthInKM { get; set; }

        public string? WalkImageUrl { get; set; }

        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }

        public Difficulty Difficulty { get; set; }

        public Region Region { get; set; }
    }
}
