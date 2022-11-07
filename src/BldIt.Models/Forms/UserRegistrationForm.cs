using System.ComponentModel.DataAnnotations;

namespace BldIt.Models.Forms
{
    public class UserRegistrationForm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}