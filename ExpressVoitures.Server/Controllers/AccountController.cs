using ExpressVoitures.Server.Models.InputModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpressVoitures.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
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
    }
}
