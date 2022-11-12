using System.ComponentModel.DataAnnotations;

namespace BldIt.Identity.Contracts.Dtos
{
    public class RegisterUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}