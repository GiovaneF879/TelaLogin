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
                From = new EmailAddress("wellingtonn.dev@gmail.com", "OngPetCare"),
                Subject = subject,
                HtmlContent = body
            };
            msg.AddTo(new EmailAddress(destination));

            var response = await _client.SendEmailAsync(msg);
        }
    }
}
