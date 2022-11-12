namespace BldIt.Identity.Contracts.Dtos
{
    public class LoginUserDto
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}