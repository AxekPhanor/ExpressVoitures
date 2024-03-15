using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Server.Models.InputModels
{
    public class VoitureInputModel
    {
        [Required]
        public string Marque { get; set; }
        [Required]
        public int Annee { get; set; }
        [Required]
        public string Modele { get; set; }
        [Required]
        public string Finition { get; set; }
    }
}
