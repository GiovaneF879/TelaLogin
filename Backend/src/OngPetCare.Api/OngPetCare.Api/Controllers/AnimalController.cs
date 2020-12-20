using Microsoft.AspNetCore.Mvc;
using OngPetCare.Api.Dto;
using OngPetCare.Api.Services;
using OngPetCare.infra.Context;
using OngPetCare.infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OngPetCare.Api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] AnimalDto model, [FromServices] DataBaseContext context)
        {
            var service = new AnimalService(context);
            var itsOk = await service.Create(model);
            if (itsOk != null)
            {
                return Ok(itsOk);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromServices] DataBaseContext context)
        {
            var service = new AnimalService(context);
            var animalsList = await service.List();
            if (animalsList != null)
            {
                return Ok(animalsList);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id, [FromServices] DataBaseContext context)
        {
            var service = new AnimalService(context);
            var model = await service.GetById(id);
            if (model != null)
            {
                return Ok(model);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("{id:int}")]
        public async Task<ActionResult> Delete(long id, [FromServices] DataBaseContext context)
        {
            var service = new AnimalService(context);
            var itsOk = await service.Delete(id);
            if (itsOk)
            {
                return Ok("Registro deletado com sucesso!");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update([FromBody] AnimalDto animal, [FromServices] DataBaseContext context)
        {
            var service = new AnimalService(context);
            var model = await service.Update(animal);
            if (model != null)
            {
                return Ok(animal);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
