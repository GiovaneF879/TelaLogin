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

                From = new EmailAddress("wellingtonntonn@gmail.com"),
                Subject = subject,
                HtmlContent = body
            };
            msg.AddTo(new EmailAddress(destination));

            var response = await _client.SendEmailAsync(msg);
        }
    }
}
