using ExpressVoitures.Server.Models;
using ExpressVoitures.Server.Models.InputModels;
using ExpressVoitures.Server.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Web;

namespace ExpressVoitures.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IMailService mailService;
        private readonly MailSettings mailSettings;
        private readonly UrlSettings urlSettings;
        public AccountController(UserManager<IdentityUser> _userManager, 
            SignInManager<IdentityUser> _signInManager, 
            IMailService mailService,
            IOptions<MailSettings> mailSettings,
            IOptions<UrlSettings> urlSettings)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            this.mailService = mailService;
            this.mailSettings = mailSettings.Value;
            this.urlSettings = urlSettings.Value;
        }
        
        [HttpPost(Name = "Register")]
        public async Task<IActionResult> Register([FromBody] AuthentificationInputModel model)
        {
            if(model.UserName == "Admin")
            {
                var user = new IdentityUser()
                {
                    UserName = model.UserName
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return Ok();
                }
            }
            return BadRequest();   
        }

        [HttpPost(Name = "Login")]
        public async Task<IActionResult> Login([FromBody] AuthentificationInputModel model)
        {
            var result = await signInManager.PasswordSignInAsync(
                model.UserName, 
                model.Password, 
                isPersistent: false, 
                lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet(Name = "Logout")]
        public async Task<IActionResult> Logout()
        {
            if (signInManager.IsSignedIn(User))
            {
                await signInManager.SignOutAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet(Name = "IsLoggedIn")]
        public IActionResult IsLoggedIn()
        {
            if (signInManager.IsSignedIn(User))
            {
                return Ok(true);
            }
            else if (!signInManager.IsSignedIn(User))
            {
                return Ok(false);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet(Name = "ResetPassword")]
        public async Task<IActionResult> ResetPassword()
        {
            var user = await userManager.FindByNameAsync("Admin");
            Console.WriteLine(user);
            if (user is null)
            {
                return BadRequest();
            }
            var code = await userManager.GeneratePasswordResetTokenAsync(user);
            var encodeUrl = HttpUtility.UrlEncode(code);
            await mailService.SendMail(new MailDataInputModel
            {
                FromName = "Express Voitures",
                FromEmail = mailSettings.ReceiverEmail,
                Subject = "Rénitialisation du mot de passe",
                Body = $"Veuillez utiliser le lien ci-dessous pour rénitialiser " +
                $"votre mot de passe<br> {urlSettings.ClientUrl}admin/reset-password?code={encodeUrl}"
            });
            return Ok();
        }

        [HttpPost(Name = "SetNewPassword")]
        public async Task<IActionResult> SetNewPassword([FromBody] NewPasswordInputModel model)
        {
            var user = await userManager.FindByNameAsync("Admin");
            if(user is null)
            {
                return BadRequest();
            }
            var decode = HttpUtility.UrlDecode(model.Code);
            var result = await userManager.ResetPasswordAsync(user, decode, model.NewPassword);
            if(!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }
    }
}
