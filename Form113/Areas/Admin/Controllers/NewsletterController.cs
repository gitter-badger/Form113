using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Form113.Areas.Admin.Models;
using System.IO;
using System.Configuration;
using System.Net.Mail;
using DataLayer.Models;
namespace Form113.Areas.Admin.Controllers
{
    public class NewsletterController : Controller
    {
        private BestArtEntities db = new BestArtEntities();

        // GET: Admin/Newsletter
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(newsLetterViewModel letter)
        {
            var utilisateur = db.AspNetUsers.ToList();
            // Envoi du mail a tout le monde :
            foreach (var item in utilisateur)
            {
                string body = PopulateBody(item.UserName, letter.Title, "www.bestArt.com", letter.Description);
                SendHtmlFormattedEmail( item.Email,"NewsLetter BestArt", body);
            }
            return View();
        }
        public ActionResult Preview(newsLetterViewModel letter)
        {

            return View("Index", letter);
        }
       
        /// <summary>
        /// Remplissage de la newsletter en fonction du nom d'utilisateur du titre et de l'url donné ainsi que de la description. 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="title"></param>
        /// <param name="url"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        private string PopulateBody(string userName,string title, string url, string description)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Areas/Admin/Scripts/NewsLetter/EmailTemplate.htm")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{UserName}", userName);
            body = body.Replace("{Title}", title);
            body = body.Replace("{Url}", url);
            body = body.Replace("{Description}", description);
            return body;
        }

        /// <summary>
        /// Envoi l'email formaté HTML
        /// </summary>
        /// <param name="recipientEmail"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        private void SendHtmlFormattedEmail(string recipientEmail, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recipientEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["Host"];
                smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"];
                NetworkCred.Password = ConfigurationManager.AppSettings["Password"];
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                smtp.Send(mailMessage);

            }
        }
    }
    
}