using ExpressVoitures.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public async Task<IActionResult> Register([FromBody] AuthentificationModel model)
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
                    return StatusCode(200, "Compte créer avec succès");
                }
            }
            return StatusCode(400, "Erreur lors de la création du compte");   
        }

        [HttpPost(Name = "Login")]
        public async Task<IActionResult> Login([FromBody] AuthentificationModel model)
        {
            var result = await signInManager.PasswordSignInAsync(
                model.UserName, 
                model.Password, 
                isPersistent: false, 
                lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return StatusCode(200, "Connexion réussi");
            }
            return StatusCode(400, "Échec de la connexion");
        }
    }
}
