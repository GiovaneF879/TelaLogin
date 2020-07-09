using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OngPetCare.Api.Dto;
using OngPetCare.Api.Models;
using OngPetCare.Api.Services;
using OngPetCare.infra.Models;
using System;
using System.Threading.Tasks;

namespace OngPetCare.Api.Controllers
{
    [Route("v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _UserManager;
        private readonly SignInManager<User> _SignManager;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _UserManager = userManager;
            _SignManager = signInManager;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserCreateDto model)
        {
            var service = new UserService(_UserManager, _SignManager);
            var itsOk = await service.Create(model);
            if (itsOk)
            {
                
                var objecResult = await service.Login(model.UserName, model.Password);

                if (objecResult.error == true)
                    return new UnauthorizedResult();

                return Ok(objecResult);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("RecoveryPassword")]
        public async Task<ActionResult> RecoveryPassword([FromBody] RecoveryPasswordDto model)
        {
            var service = new UserService(_UserManager, _SignManager);
            var itsOk = await service.RecoveryPassword(model);
            if (itsOk)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
