using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.Common;
using WebAPI.DAL;
using WebAPI.Models;
using WebAPI.ViewModels;
namespace WebAPI.Controllers
{
    public class TailorMakeController : ApiController
    {
        private MyDbContext _db = new MyDbContext();
        public async Task Post(TailorMake data)
        {
            data.Ip = Util.getIP();
            data.Device = Util.getBrowser();
            data.Id = Guid.NewGuid();
            data.CreateDate = DateTime.Now;
            await Task.Run(delegate
            {
                TailorMakeController.SendEmail(data);
            });
            this._db.TailorMakeData.Add(data);
            this._db.SaveChanges();
        }
        private static void SendEmail(TailorMake data)
        {
            var addresses = Convert.ToString(ConfigurationManager.AppSettings["toEmail"]).Split(',').ToList();
            foreach (var address in addresses)
            {
                SendAEmail(data, address);
            }
        }

        private static void SendAEmail(TailorMake data,string addresses)
        {
            string text = ConfigurationManager.AppSettings["sendEmail"];
            string password = ConfigurationManager.AppSettings["sendEmailPassword"];
            string host = ConfigurationManager.AppSettings["emailSmtp"];
            string value = ConfigurationManager.AppSettings["emailPort"];
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(text)
            };
            mailMessage.To.Add(addresses);
            mailMessage.Subject = TailorMakeController.GetEmailSubject(data);
            string emailContent = TailorMakeController.GetEmailContent(data);
            mailMessage.Body = emailContent;
            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.Priority = MailPriority.High;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(text, password);
            smtpClient.Port = Convert.ToInt32(value);
            smtpClient.Host = host;
            smtpClient.EnableSsl = false;
            try
            {
                SmtpClient arg_E3_0 = smtpClient;
                MailMessage expr_E2 = mailMessage;
                arg_E3_0.SendAsync(expr_E2, expr_E2);
            }
            catch (SmtpException)
            {
            }
        }


        private static string GetEmailSubject(TailorMake data)
        {
            return string.Format("{0} Tailor make from {1}{2}", "ChinaXianTour", MyEnums.getSex(data.Sex), data.FullName);
        }

        private static string GetEmailContent(TailorMake data)
        {
            string text = string.Empty;
            text = text + string.Format("<strong>{0}{1}</strong> is {2}", MyEnums.getSex(data.Sex), data.FullName, MyEnums.getIAm(data.TripPurpose)) + "<br/>";
            text = text + "<strong>Email:</strong>" + string.Format("{0}", data.Email) + "<br/>";
            text = text + "<strong>Phone:</strong>" + string.Format("{0}", data.PhoneNumber) + "<br/>";
            text = text + "<strong>Nationality:</strong>" + string.Format("{0}", data.Nationnality) + "<br/><br/>";
            text = text + "<strong>Date of Arrival:</strong>" + string.Format("{0}", (!data.ArrivalDate.HasValue) ? string.Empty : data.ArrivalDate.Value.ToString("yyyy-MM-dd")) + "<br/>";
            text = text + "<strong>Travel with:</strong>" + string.Format("{0}", MyEnums.getTravelWith(data.TravelWithType)) + " <br/>";
            if (data.TravelWithType > 1)
            {
                text = string.Concat(new object[]
                {
                    text,
                    "<strong>Adults:</strong>",
                    data.NumbersOfMyGroupAdult,
                    " <strong>Children:</strong>",
                    data.NumbersOfMyGroupChild,
                    " <br/>"
                });
            }
            text = text + "<strong>Trip Length:</strong>" + string.Format("{0}", data.TourLengthAround) + "<br/>";
            text = text + "<strong>Flexible:</strong>" + string.Format("{0}", (data.DatesFlexible == 1) ? "True" : "False") + "<br/>";
            text = text + "<strong>Hotel Style:</strong>" + string.Format("{0}", MyEnums.getHotelStyle(data.HotelStyle)) + "<br/>";
            text = text + "<strong>GuideAndFreetime:</strong>" + string.Format("{0}", MyEnums.getGuideAndFreetime(data.GuideAndFreetime)) + "<br/>";
            text = text + "<strong>Train v Plane:</strong>" + string.Format("{0}", MyEnums.getTrainAndPlane(data.TrainAndPlane)) + "<br/><br/>";
            text = text + "<strong>Cities:</strong>" + string.Format("{0}", string.IsNullOrEmpty(data.TripCities) ? string.Empty : data.TripCities.Trim(new char[]
            {
                ','
            })) + "<br/>";
            text = text + "<strong>Ideal trip:</strong>" + string.Format("{0}", data.IdealTrip) + "<br/><br/>";
            text = text + "<strong>IP:</strong>" + string.Format("{0}", data.Ip) + "<br/>";
            text = text + "<strong>Country:</strong>" + string.Format("{0}", Util.Ip2Country(data.Ip)) + "<br/>";
            text = text + "<strong>Device:</strong>" + string.Format("{0}", data.Device) + "<br/><br/>";
            return string.Concat(new string[]
            {
                text,
                "<strong>From Tour:</strong><a href=\"",
                data.TourUrl,
                "\">",
                string.Format("{0}", data.TourDetail),
                "</a><br/>"
            });
        }
    }
}
