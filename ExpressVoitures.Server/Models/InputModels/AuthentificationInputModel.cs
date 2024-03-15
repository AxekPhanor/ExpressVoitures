using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Server.Models.InputModels
{
    public class AuthentificationInputModel
    {
        [Required]
        public string UserName {  get; set; }
        [Required]
        public string Password { get; set; }
    }
}
