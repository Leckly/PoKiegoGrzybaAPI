namespace PoKiegoGrzybaAPI.Data.Req
{
    public class UserRegisterData
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public byte[]? Avatar { get; set; }
    }
}
