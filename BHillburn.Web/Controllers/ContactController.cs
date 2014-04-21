
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Mail;
using MailMessage = System.Net.Mail.MailMessage;

namespace BHilburn.Web.Controllers
{

    using System;
    using System.Web.Mvc;

    using BHilburn.Web.Models.Contact;


    public class ContactController : Controller
    {
        public ActionResult Index()
        {
            return View(new ContactViewModel());      
        }

        // GET: /Contact/
        [HttpPost]
        public ActionResult EmailBri(ContactViewModel submittedContactViewModel)
        {
            try
            {
                var message = new MailMessage();
                message.From = new MailAddress("jesseeuton@gmail.com");

                var toAddy1 = new MailAddress("bri.euton@jhilburnpartner.com");
                var toAddy2 = new MailAddress("jesseeuton@gmail.com");
                
                message.To.Add(toAddy1);
                message.To.Add(toAddy2);

                message.Subject = "Inquiry from BriEuton.com";
                var builder = new StringBuilder();
                builder.AppendLine(string.Format("Name: {0}", submittedContactViewModel.Name));
                builder.AppendLine(string.Format("Email: {0}", submittedContactViewModel.Email));
                builder.AppendLine(string.Format("Phone: {0}", submittedContactViewModel.Phone));
                builder.AppendLine(string.Format("Info: {0}", submittedContactViewModel.Info));
                message.Body = builder.ToString();

                
                var client = new SmtpClient("smtp.gmail.com", 587);
                client.Credentials = new NetworkCredential("jesseeuton@gmail.com", "G81238045*");
                client.EnableSsl = true;

                client.Send(message);
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("Index", "Home");
        }
    }
}
