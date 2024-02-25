﻿using ExpressVoitures.Server.Models.InputModels;
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
            if (await voitureEnregistreService.Create(voitureEnregistre))
            {
                return Created("201", voitureEnregistre);
            }
            return BadRequest();
        }

        [HttpGet("GetAll")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var result = await voitureEnregistreService.GetAll();
            if (result is not [])
            {
                return Ok(result);
            }
            return BadRequest();
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
            return BadRequest();
        }

        [HttpPut("Update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] VoitureEnregistreInputModel voitureEnregistre)
        {
            if (await voitureEnregistreService.Update(voitureEnregistre, id))
            {
                return Ok(voitureEnregistre);
            }
            return BadRequest();
        }

        [HttpDelete("DeleteById")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            if (await voitureEnregistreService.DeleteById(id))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
