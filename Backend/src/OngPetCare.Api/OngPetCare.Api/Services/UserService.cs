using Microsoft.AspNetCore.Identity;
using OngPetCare.infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngPetCare.Api.Services
{
    public class UserService
    {
        private readonly UserManager<User> _UserManager;
        private readonly SignInManager<User> _SignManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _UserManager = userManager;
            _SignManager = signInManager;
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _UserManager.FindByEmailAsync(email);
            var okPassword = await _SignManager.CheckPasswordSignInAsync(user, password, false);

            if (okPassword.Succeeded){
                var token = TokenService.GenerateToken(user);
                return token;
            }
            else
            {
                return "";
            }
        }
    }
}
