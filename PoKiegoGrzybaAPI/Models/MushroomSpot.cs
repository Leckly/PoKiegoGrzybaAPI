﻿using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PoKiegoGrzybaAPI.Models
{
    public class MushroomSpot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? SpotName { get; set; }
        public string? Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [JsonPropertyName("userID")]
        public long MushroomHunterId { get; set; }
        [JsonIgnore]
        public virtual MushroomHunter MushroomHunter { get; set; }
    }
}
