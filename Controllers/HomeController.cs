using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebAPI.Common;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("/index.html");
        }


        public void TestFireExe()
        {
            return;
            const string path = "D:\\mydemo\\ks\\dataHistory\\KsHistoryData\\KsHistoryData\\bin\\Release\\KsHistoryData.exe";
            System.Diagnostics.Process.Start(path);
        }


        public async Task TestSendAEmail()
        {
            await Task.Run(() => SendAEmail());
        }


        public void TestEmail()
        {
            SMail();
        }

        private static void SMail()
        {
            SmtpClient client = new SmtpClient("smtp.sina.com");
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network; 
            client.Credentials = new NetworkCredential("klforever18@sina.com", "chenwei8");
            client.EnableSsl = true;
            MailMessage mmsg = new MailMessage(new MailAddress("klforever18@sina.com", "hello"), new MailAddress("12833318@qq.com")); 

            mmsg.Subject = "TEST"; 
            mmsg.SubjectEncoding = Encoding.UTF8;
            mmsg.Body = "Test content" + "Time" + System.DateTime.Now.ToString().Trim();

            mmsg.BodyEncoding = Encoding.UTF8;

            mmsg.IsBodyHtml = true;

            mmsg.Priority = MailPriority.High; 

            client.Send(mmsg);

            //var client = new SmtpClient("smtp.chinaxiantour.com",25);
            //client.Send("tour@chinaxiantour.com", "12833318@qq.com", "test", "testContent");
        }

        private static void SendAEmail()
        {
            var sendEmail = ConfigurationManager.AppSettings["sendEmail"];

            var sendEmailPassword = ConfigurationManager.AppSettings["sendEmailPassword"];
            var emailSmtp = ConfigurationManager.AppSettings["emailSmtp"];
            var emailPort = ConfigurationManager.AppSettings["emailPort"];
            var mailMsg = new MailMessage { From = new MailAddress(sendEmail) };
            var addresses = Convert.ToString(ConfigurationManager.AppSettings["toEmail"]).Split(',').ToList();
            foreach (var address in addresses)
            {
                mailMsg.To.Add(address);
            }
            mailMsg.Subject = "Test";
            var emailContent = "Test content";
            mailMsg.Body = emailContent;
            mailMsg.BodyEncoding = Encoding.UTF8;
            mailMsg.IsBodyHtml = true;
            mailMsg.Priority = MailPriority.High;
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential(sendEmail, sendEmailPassword);
            smtp.Port = Convert.ToInt32(emailPort);
            smtp.Host = emailSmtp;
            smtp.EnableSsl = false;
            smtp.SendMailAsync(mailMsg);
        }
    }
}