using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Common
{
    public class Mailer : IMailer
    {
        public void Send(string toAdress, string subject, string body)
        {
            var client = new SmtpClient();
            client.Send(FriendlyFromAddress, toAdress, subject, body);
        }
        private static string FriendlyFromAddress
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(
                    ConfigurationManager.AppSettings["FriendlyFromAddress"]))
                {
                    return ConfigurationManager.AppSettings["FriendlyFromAddress"];
                }
                throw new Exception("No friendly from address is set in the webconfig");
            }
        }
    }
}
