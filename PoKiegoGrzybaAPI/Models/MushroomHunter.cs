using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoKiegoGrzybaAPI.Models
{
    public class MushroomHunter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string EmailAdress { get; set; }
        public long? Points { get; set; }
        public byte[]? Avatar { get; set; }

        public virtual ICollection<MushroomSpot> MushroomSpot { get; set; }
    }
}
