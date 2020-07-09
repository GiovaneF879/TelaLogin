using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OngPetCare.Api.Services
{
    public class EmailSMTPService
    {
        public void ExecSendEmail(string destination, string subject, string body)
        {
            var user = "testewellingtonn@gmail.com";
            var password = "testewtestew2";
            var fromName = "OngPetCare";
            var hostSmtp = "smtp.gmail.com";
            var portSmtp = 587;

            MailMessage objeto_mail = new MailMessage();
            SmtpClient client = new SmtpClient();

            client.Port = portSmtp;
            client.Host = hostSmtp;
            client.Timeout = 6000;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(user, password);

            objeto_mail.From = new MailAddress(user, fromName);

            objeto_mail.To.Add(new MailAddress(destination));

            objeto_mail.SubjectEncoding = System.Text.Encoding.UTF8;
            objeto_mail.Subject = subject;

            objeto_mail.BodyEncoding = System.Text.Encoding.UTF8;
            objeto_mail.Body = body;
            objeto_mail.IsBodyHtml = true;

            client.Send(objeto_mail);
        }
    }
}
