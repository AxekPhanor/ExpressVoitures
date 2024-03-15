namespace ExpressVoitures.Server.Models.InputModels
{
    public class MailDataInputModel
    {
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
