using Microsoft.Identity.Client;
using PoKiegoGrzybaAPI.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoKiegoGrzybaAPI.Models
{
    public class Mushroom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public Category Category { get; set; }
        public MushroomType Type { get; set; }
        public byte[] Image { get; set; }
    }
}
