using System.ComponentModel.DataAnnotations;

namespace PoKiegoGrzybaAPI.Data.Req
{
    public class MushroomSpotAdd
    {
        [Required]
        public string SpotName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public long UserID { get; set; }
    }
}
