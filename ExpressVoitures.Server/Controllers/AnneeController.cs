using ExpressVoitures.Server.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpressVoitures.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnneeController : ControllerBase
    {
        private readonly IAnneeService anneeService;
        public AnneeController(IAnneeService anneeService)
        {
            this.anneeService = anneeService;
        }

        [HttpGet("GetAll")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var result = await anneeService.GetAll();
            return Ok(result);
        }
    }
}
