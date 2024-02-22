namespace ExpressVoitures.Server.Models
{
    public class Voiture
    {
        public int Id { get; set; }
        public string Marque { get; set; }
        public int Annee {  get; set; }
        public string Modele { get; set; }
        public string Finition { get; set; }
        public List<VoitureEnregistre>? VoituresEnregistre {  get; set; }
    }
}
