using ExpressVoitures.Server.Models.InputModels;
using ExpressVoitures.Server.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpressVoitures.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnonceController : ControllerBase
    {
        private readonly IAnnonceService annonceService;
        public AnnonceController(IAnnonceService annonceService)
        {
            this.annonceService = annonceService;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] AnnonceInputModel annonce)
        {
            if (await annonceService.Create(annonce))
            {
                return Created("201", annonce);
            }
            return BadRequest();
        }

        [HttpGet("GetAll")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var result = await annonceService.GetAll();
            return Ok(result);
        }

        [HttpGet("GetAllAvailable")]
        public async Task<IActionResult> GetAllAvailable()
        {
            var result = await annonceService.GetAllAvailable();
            return Ok(result);
        }

        [HttpGet("GetById")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await annonceService.GetById(id);
            if (result is not null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("GetByIdAvailable")]
        public async Task<IActionResult> GetByIdAvailable([FromQuery] int id)
        {
            var result = await annonceService.GetByIdAvailable(id);
            if (result is not null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPut("Update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] AnnonceInputModel annonce)
        {
            if (await annonceService.Update(annonce, id))
            {
                return Ok(annonce);
            }
            return BadRequest();
        }

        [HttpDelete("DeleteById")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            if (await annonceService.DeleteById(id))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("Sold")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Sold([FromQuery] int id)
        {
            var result = await annonceService.Sold(id);
            if (result)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("UploadImg")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UploadImg(IFormFile file, [FromQuery] int id)
        {
            await annonceService.Upload(file, id);
            return Ok();
        }
    }
}
