using MedinaOfSpices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MedinaOfSpices.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(EmailModel obj)
        {

            try
            {
                //Configuring webMail class to send emails  
                //gmail smtp server  
                WebMail.SmtpServer = "smtp.gmail.com";
                //gmail port to send emails  
                WebMail.SmtpPort = 587;
                WebMail.SmtpUseDefaultCredentials = true;
                //sending emails with secure protocol  
                WebMail.EnableSsl = true;
                //EmailId used to send emails from application  
                WebMail.UserName = System.Configuration.ConfigurationManager.AppSettings["CCEmail"];
                WebMail.Password = System.Configuration.ConfigurationManager.AppSettings["CCEmailPassword"];

                //Sender email address.  
                WebMail.From = System.Configuration.ConfigurationManager.AppSettings["CCEmail"];
                WebMail.EnableSsl = true;
                //Send email  
                WebMail.Send(to: obj.ToEmail, subject: obj.EmailSubject, body: obj.EMailBody, cc: obj.EmailCC, bcc: obj.EmailBCC, isBodyHtml: true);
                ViewBag.Status = "Email Sent Successfully.";
            }
            catch (Exception ex)
            {
                ViewBag.Status = "Problem while sending email, Please check details: " + ex.Message.ToString();

            }
            return View("Index");
        }
    }
}
