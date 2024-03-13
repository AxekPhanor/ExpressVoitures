using ExpressVoitures.Server.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpressVoitures.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinitionController : ControllerBase
    {
        private readonly IFinitionService finitionService;
        public FinitionController(IFinitionService finitionService)
        {
            this.finitionService = finitionService;
        }

        [HttpGet("GetAll")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var result = await finitionService.GetAll();
            return Ok(result);
        }
    }
}
