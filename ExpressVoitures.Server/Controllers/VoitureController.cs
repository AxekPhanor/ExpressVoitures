using ExpressVoitures.Server.Models.InputModels;
using ExpressVoitures.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpressVoitures.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VoitureController : ControllerBase
    {
        private readonly IVoitureService voitureService;
        public VoitureController(IVoitureService voitureService)
        {
            this.voitureService = voitureService;
        }

        [HttpPost(Name = "Create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] VoitureInputModel voiture)
        {
            if(await voitureService.Create(voiture))
            {
                return Created("201" , voiture);
            }
            return BadRequest();
        }

        [HttpGet(Name = "GetAll")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var result = await voitureService.GetAll();
            if (result is not [])
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet(Name = "GetById")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await voitureService.GetById(id);
            if(result is not null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut(Name = "Update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] VoitureInputModel voiture)
        {
            if(await voitureService.Update(voiture, id))
            {
                return Ok(voiture);
            }
            return BadRequest();
        }

        [HttpDelete(Name = "DeleteById")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            if(await voitureService.DeleteById(id))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
