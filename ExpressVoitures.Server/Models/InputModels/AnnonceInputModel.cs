namespace ExpressVoitures.Server.Models.InputModels
{
    public class AnnonceInputModel
    {
        public int VoitureEnregistreId { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public List<string> Photos { get; set; }
        public double PrixVente { get; set; }
    }
}
