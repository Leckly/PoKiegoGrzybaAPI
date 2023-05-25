using System.ComponentModel.DataAnnotations;

namespace PoKiegoGrzybaAPI.Data.Req
{
    public class UserRegisterData
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
