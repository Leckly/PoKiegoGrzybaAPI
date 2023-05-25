using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PoKiegoGrzybaAPI.Data.Req
{
    public class UserLogInData
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
