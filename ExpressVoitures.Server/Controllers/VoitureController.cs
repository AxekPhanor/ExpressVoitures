using ExpressVoitures.Server.Models.Entities;
using ExpressVoitures.Server.Models.InputModels;
using ExpressVoitures.Server.Models.Services;
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

        [HttpPost()]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] VoitureInputModel voiture)
        {
            var result = await voitureService.Create(voiture);
            return Created("201" , result);
        }

        [HttpGet()]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var result = await voitureService.GetAll();
            return Ok(result);
        }

        [HttpGet()]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await voitureService.GetById(id);
            if(result is not null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPut()]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] VoitureInputModel voiture)
        {
            if (await voitureService.Update(voiture, id))
            {
                return Ok(voiture);
            }
            return NotFound();
        }

        [HttpDelete()]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            if(await voitureService.DeleteById(id))
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPost()]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Exist([FromBody] VoitureInputModel voiture)
        {
            var result = await voitureService.Exist(voiture);
            return Ok(result);
        }
    }
}
