using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Server.Models
{
    public class AuthentificationModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
