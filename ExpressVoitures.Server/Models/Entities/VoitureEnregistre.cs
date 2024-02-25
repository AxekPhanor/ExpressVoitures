using System.ComponentModel.DataAnnotations;

namespace ExpressVoitures.Server.Models.Entities
{
    public class VoitureEnregistre
    {
        public int Id { get; set; }
        public DateTime DateAchat { get; set; }
        public double PrixAchat { get; set; }
        public string Reparations { get; set; }
        public int CoutReparations { get; set; }
        public int VoitureId { get; set; }
        public Voiture Voiture { get; set; }
        public Annonce? Annonce { get; set; }
    }
}
