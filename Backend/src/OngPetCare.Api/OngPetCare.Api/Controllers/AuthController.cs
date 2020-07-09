using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OngPetCare.Api.Models;
using OngPetCare.Api.Services;
using OngPetCare.infra.Models;
using System;
using System.Threading.Tasks;

namespace OngPetCare.Api.Controllers
{
    [Route("v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _UserManager;
        private readonly SignInManager<User> _SignManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _UserManager = userManager;
            _SignManager = signInManager;
        }

        [HttpPost]
        public async Task<ActionResult> Authenticate([FromBody] UserLoginDto model)
        {
            var service = new UserService(_UserManager, _SignManager);
            var objecResult = await service.Login(model.UserName, model.Password);

            if (objecResult.error == true)
                return new UnauthorizedResult();

            return Ok(objecResult);
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee,manager")]
        public string Employee() => "Funcionário";

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]
        public string Manager() => "Gerente";
    }
}
