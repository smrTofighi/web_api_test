﻿using System.ComponentModel.DataAnnotations;

namespace CityInfoApi.Models
{
    public class PointOfInterestForUpdateDto
    {
        [Required(ErrorMessage = "The name city is required!")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;
    }
}
