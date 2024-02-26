namespace ExpressVoitures.Server.Models.InputModels
{
    public class AnnonceOutputModel
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public List<string> Photos { get; set; }
        public DateTime DateCreation { get; set; }
        public double PrixVente { get; set; }
        public DateTime? DateVente { get; set; }
        public int VoitureEnregistreId { get; set; }
    }
}
