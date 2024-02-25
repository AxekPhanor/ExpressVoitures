namespace ExpressVoitures.Server.Models.InputModels
{
    public class VoitureEnregistreInputModel
    {
        public int VoitureId { get; set; }
        public DateTime DateAchat { get; set; }
        public double PrixAchat { get; set; }
        public string Reparations { get; set; }
        public int CoutReparations { get; set; }
    }
}
