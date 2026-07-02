using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;

namespace Server.Services
{
    public class EmailService
    {
        private readonly string SenderEmail = ConfigurationManager.AppSettings["SenderEmail"];

        private readonly string SenderDisplayName = ConfigurationManager.AppSettings["SenderDisplayName"];

        private readonly string SmtpHost = ConfigurationManager.AppSettings["SmtpHost"];

        private readonly int SmtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);

        private readonly string SmtpUser = ConfigurationManager.AppSettings["SmtpUser"];

        private readonly string SmtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];
        public void PosaljiMail(string primalac,string naslov, string html, string replyTo = null)
        {
            MailMessage poruka = new MailMessage();

            poruka.From = new MailAddress(SenderEmail, SenderDisplayName);

            // validiraj email adresu primaoca
            if (string.IsNullOrWhiteSpace(primalac) || !MailAddress.TryCreate(primalac, out var toAddress))
            {
                Debug.WriteLine($"Neispravna adresa primaoca: '{primalac}' - preskacem slanje.");
                return; 
            }
            poruka.To.Add(toAddress);

            poruka.Subject = naslov;
            poruka.Body = html;
            poruka.IsBodyHtml = true;

            if (!string.IsNullOrWhiteSpace(replyTo))
            {
                // validiraj Reply-To pre dodavanja
                if (MailAddress.TryCreate(replyTo, out var replyAddress))
                {
                    poruka.ReplyToList.Add(replyAddress);
                }
                else
                {
                    Debug.WriteLine($"Neispravna Reply-To adresa: '{replyTo}' - ignorisano.");
                }
            }

            SmtpClient smtp = new SmtpClient(SmtpHost, SmtpPort);

            smtp.EnableSsl = true;

            smtp.Credentials = new NetworkCredential( SmtpUser, SmtpPassword);

            smtp.Send(poruka);
        }
    }
}
