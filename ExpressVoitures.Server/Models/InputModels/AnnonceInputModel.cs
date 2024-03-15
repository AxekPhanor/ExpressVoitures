using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Server.Models.InputModels
{
    public class AnnonceInputModel
    {
        public int VoitureEnregistreId { get; set; }
        public string Titre { get; set; }
        [Required]
        public string Description { get; set; }
        public List<string> Photos { get; set; }
        [Required]
        public double PrixVente { get; set; }
    }
}
