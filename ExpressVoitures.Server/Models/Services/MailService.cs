using ExpressVoitures.Server.Models.InputModels;
using Microsoft.Extensions.Options;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json.Linq;
using Mailjet.Client.TransactionalEmails;

namespace ExpressVoitures.Server.Models.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            this.mailSettings = mailSettings.Value;
        }

        public async Task<bool> SendMail(MailDataInputModel mailData)
        {
            var client = new MailjetClient(mailSettings.ApiKey, mailSettings.SecretKey);
            var request = new TransactionalEmailBuilder()
                .WithFrom(new SendContact(mailData.FromEmail, mailData.FromName))
                .WithSubject(mailData.Subject)
                .WithHtmlPart(mailData.Body)
                .WithTo(new SendContact(mailSettings.SenderEmail))
                .Build();

            var response = await client.SendTransactionalEmailAsync(request);
            Console.WriteLine(mailSettings.SenderEmail);
            Console.WriteLine(response);
            if (response is not null)
            {
                return true;
            }
            return false;
        }
    }
}
