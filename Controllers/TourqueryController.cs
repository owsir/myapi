using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI.Common;
using WebAPI.DAL;
using WebAPI.Models;
using System.Configuration;

namespace WebAPI.Controllers
{
    public class TourqueryController : ApiController
    {
        MyDbContext _db = new MyDbContext();

        // POST api/tourquery
        public async Task Post(Tourquery query)
        {
            query.Ip = Util.getIP();
            query.Device = Util.getBrowser();
            query.Id = Guid.NewGuid();
            query.CreateDate = DateTime.Now;
            await Task.Run(() => SendEmail(query));
            _db.TourqueryData.Add(query);
            _db.SaveChanges();
        }

        private static void SendEmail(Tourquery data)
        {
            var addresses = Convert.ToString(ConfigurationManager.AppSettings["toEmail"]).Split(',').ToList();
            foreach (var address in addresses)
            {
                SendAEmail(data, address);
            }
        }

        private static void SendAEmail(Tourquery query,string address)
        {
            var sendEmail = ConfigurationManager.AppSettings["sendEmail"];
            var toEmail = address;
            var sendEmailPassword= ConfigurationManager.AppSettings["sendEmailPassword"];
            var emailSmtp = ConfigurationManager.AppSettings["emailSmtp"];
            var emailPort = ConfigurationManager.AppSettings["emailPort"];
            var mailMsg = new MailMessage {From = new MailAddress(sendEmail) };
            mailMsg.To.Add(toEmail);
            //mailMsg.To.Add("another email");
            mailMsg.Subject = string.Format("Query from {0}", query.Name);
            var text = string.Format("<strong>Email:</strong>{0}<br/><strong>Detail:</strong>{1}<br/>", query.Email, query.Content);
            text = text + "<br/><br/><strong>IP:</strong>" + string.Format("{0}", query.Ip) + "<br/>";
            text = text + "<strong>Country:</strong>" + string.Format("{0}", Util.Ip2Country(query.Ip)) + "<br/>";
            text = text + "<strong>Device:</strong>" + string.Format("{0}", query.Device) + "<br/><br/>";
            text = string.Concat(new string[]
            {
                            text,
                            "<strong>From Tour:</strong><a href=\"",
                            "http://www.chinaxiantour.com"+query.FromUrl,
                            "\">",
                            string.Format("{0}", query.TourUrl),
                            "</a><br/>"
            });
            var emailContent = text;
            mailMsg.Body = emailContent;
            mailMsg.BodyEncoding = Encoding.UTF8;
            mailMsg.IsBodyHtml = true;
            mailMsg.Priority = MailPriority.High;
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential(sendEmail, sendEmailPassword);
            smtp.Port = Convert.ToInt32(emailPort); 
            smtp.Host = emailSmtp; 
            smtp.EnableSsl = false; 
            try
            {
                smtp.SendAsync(mailMsg, mailMsg);
            }
            catch (SmtpException ex)
            {
                
            }
        }
    }
}

