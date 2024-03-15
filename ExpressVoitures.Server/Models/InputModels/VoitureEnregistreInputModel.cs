using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Server.Models.InputModels
{
    public class VoitureEnregistreInputModel
    {
        [Required]
        public int VoitureId { get; set; }
        [Required]
        public DateTime DateAchat { get; set; }
        [Required]
        public double PrixAchat { get; set; }
        [Required]
        public string Reparations { get; set; }
        [Required]
        public int CoutReparations { get; set; }
    }
}
