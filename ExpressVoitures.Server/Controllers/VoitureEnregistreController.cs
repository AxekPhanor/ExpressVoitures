using ExpressVoitures.Server.Models.InputModels;
using ExpressVoitures.Server.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpressVoitures.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoitureEnregistreController : ControllerBase
    {
        private readonly IVoitureEnregistreService voitureEnregistreService;
        public VoitureEnregistreController(IVoitureEnregistreService voitureEnregistreService)
        {
            this.voitureEnregistreService = voitureEnregistreService;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] VoitureEnregistreInputModel voitureEnregistre)
        {
            var result = await voitureEnregistreService.Create(voitureEnregistre);
            if (result != 0)
            {
                return Created("201", result);
            }
            return BadRequest();
        }

        [HttpGet("GetAll")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var result = await voitureEnregistreService.GetAll();
            return Ok(result);
        }

        [HttpGet("GetById")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await voitureEnregistreService.GetById(id);
            if (result is not null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPut("Update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] VoitureEnregistreInputModel voitureEnregistre)
        {
            if (await voitureEnregistreService.Update(voitureEnregistre, id))
            {
                return Ok(voitureEnregistre);
            }
            return NotFound();
        }

        [HttpDelete("DeleteById")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            if (await voitureEnregistreService.DeleteById(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
