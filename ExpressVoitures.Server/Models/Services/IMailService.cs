using ExpressVoitures.Server.Models.InputModels;

namespace ExpressVoitures.Server.Models.Services
{
    public interface IMailService
    {
        public Task<bool> SendMail(MailDataInputModel mailData);
    }
}
