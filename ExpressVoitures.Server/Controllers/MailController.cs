using ExpressVoitures.Server.Models.InputModels;
using ExpressVoitures.Server.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpressVoitures.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService mailService;
        public MailController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        [HttpPost("Send")]
        public async Task<IActionResult> Send(MailDataInputModel mailData)
        {
            if(await mailService.SendMail(mailData)){
               return Ok();
            }
            return BadRequest();
        }
    }
}
