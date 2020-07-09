using Microsoft.AspNetCore.Identity;
using OngPetCare.Api.Dto;
using OngPetCare.Api.Models;
using OngPetCare.infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<dynamic> Login(string email, string password)
        {
            var user = await _UserManager.FindByEmailAsync(email);
            var okPassword = await _SignManager.CheckPasswordSignInAsync(user, password, false);

            if (okPassword.Succeeded){
                var token = TokenService.GenerateToken(user);
                return new { token, user, error = false};
            }
            else
            {
                return new { error = true };
            }
        }

        public async Task<dynamic> Create(UserCreateDto dto)
        {
            var result = await _UserManager.CreateAsync(new User()
            {
                UserName = dto.UserName,
                Email = dto.Email,
                FullName = dto.Name
            }, dto.Password);

            return result.Succeeded;
        }

        public async Task<dynamic> RecoveryPassword(RecoveryPasswordDto dto)
        {

            try
            {
                var user = await _UserManager.FindByEmailAsync(dto.Email);
                var password = GeneratePassword(8);
                var token = await _UserManager.GeneratePasswordResetTokenAsync(user);
                var result = await _UserManager.ResetPasswordAsync(user, token, password);
                if (result.Succeeded == false)
                {
                    throw new Exception();
                }

                var email = $"<p>Olá {user.UserName}, sua nova senha é {password}";
                var emailService = new EmailSMTPService();
                emailService.ExecSendEmail(dto.Email, "Recuperação de senha", email);

                return result.Succeeded;
            }
            catch(Exception ex)
            {
                return false;
            }

           
        }

        private string GeneratePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}
