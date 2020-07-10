using Microsoft.AspNetCore.Identity;

namespace OngPetCare.Api.Models
{
    public class UserCreateDto
    {
        public string Email{ get; set; }
        public string Password { get; set; }
    }
}
