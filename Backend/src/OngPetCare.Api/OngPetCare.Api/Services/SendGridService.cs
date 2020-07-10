using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngPetCare.Api.Services
{
    public class SendGridService
    {
        public async Task ExecSendEmailAsync(string destination, string subject, string body)
        {
            var _client = new SendGridClient("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");
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("azure_9b0ff3bd5f1985a117090687372c73b0@azure.com"),
                Subject = subject,
                HtmlContent = body
            };
            msg.AddTo(new EmailAddress(destination));

            var response = await _client.SendEmailAsync(msg);
        }
    }
}
