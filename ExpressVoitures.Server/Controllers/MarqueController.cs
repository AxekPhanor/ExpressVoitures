using ExpressVoitures.Server.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpressVoitures.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarqueController : ControllerBase
    {
        private readonly IMarqueService marqueService;
        public MarqueController(IMarqueService marqueService)
        {
            this.marqueService = marqueService;
        }

        [HttpGet("GetAll")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var result = await marqueService.GetAll();
            return Ok(result);
        }
    }
}
