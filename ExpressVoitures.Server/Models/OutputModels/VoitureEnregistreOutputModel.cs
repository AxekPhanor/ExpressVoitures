namespace ExpressVoitures.Server.Models.OutputModels
{
    public class VoitureEnregistreOutputModel
    {

        public int Id { get; set; }
        public int VoitureId { get; set; }
        public string Voiture { get; set; }
        public DateTime DateAchat { get; set; }
        public double PrixAchat { get; set; }
        public string Reparations { get; set; }
        public int CoutReparations { get; set; }
        
    }
}
