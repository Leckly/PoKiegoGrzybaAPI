using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PoKiegoGrzybaAPI.Models
{
    public class MushroomSpot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? SpotName { get; set; }
        [Required]
        public Point Point { get; set; }
        public int MushroomId { get; set; }
        public virtual Mushroom Mushroom { get; set; }
    }
}
