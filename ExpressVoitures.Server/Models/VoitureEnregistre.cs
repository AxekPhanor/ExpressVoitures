namespace ExpressVoitures.Server.Models
{
    public class VoitureEnregistre
    {
        public int Id { get; set; }
        public DateTime DateAchat { get; set; }
        public double PrixAchat { get; set; }
        public string Reparations { get; set; }
        public string CoutReparations { get; set; }
        public Voiture Voiture { get; set; }
        public Annonce? Annonce { get; set; }
    }
}
