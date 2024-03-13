namespace ExpressVoitures.Server.Models.Entities
{
    public class Voiture
    {
        public int Id { get; set; }
        public int MarqueId { get; set; }
        public int AnneeId { get; set; }
        public int ModeleId { get; set; }
        public int FinitionId { get; set; }
        public Marque Marque { get; set; }
        public Annee Annee { get; set; }
        public Modele Modele { get; set; }
        public Finition Finition { get; set; }
        public List<VoitureEnregistre>? VoituresEnregistre { get; set; }

        public override string ToString()
        {
            return $"{Marque.Nom} {Annee.Valeur} {Modele.Nom} {Finition.Nom}";
        }
    }
}
