using ExpressVoitures.Server.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpressVoitures.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeleController : ControllerBase
    {
        private readonly IModeleService modeleService;
        public ModeleController(IModeleService modeleService)
        {
            this.modeleService = modeleService;
        }
        [HttpGet("GetAll")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var result = await modeleService.GetAll();
            return Ok(result);
        }
    }
}
