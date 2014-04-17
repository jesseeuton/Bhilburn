
using System.Net.Mail;
using System.Text;

namespace BHilburn.Web.Controllers
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using BHilburn.Web.Models.Contact;


    public class ContactController : Controller
    {
        //
        // GET: /Contact/
        [HttpPost, HttpGet]
        public ActionResult Index(ContactViewModel viewModel)
        {
            if (viewModel == null ||
                (string.IsNullOrEmpty(viewModel.Name)
                 && string.IsNullOrEmpty(viewModel.Info)
                 && string.IsNullOrEmpty(viewModel.Email)
                 && string.IsNullOrEmpty(viewModel.Phone)))
            {
                viewModel = new ContactViewModel();
                return View(viewModel);   
            }
            else
            {
                SubmitContactInfo(viewModel);
                return RedirectToAction("Index", "Home");
            }
        }

        private void SubmitContactInfo(ContactViewModel model)
        {
            try
            {
                var message = new MailMessage();
                message.From = new MailAddress(model.Email.Trim());
                
                var toAddy1 = new MailAddress("bri.euton@jhilburnpartner.com");
                var toAddy2 = new MailAddress("jesseeuton@gmail.com");
                message.To.Add(toAddy1);
                message.To.Add(toAddy2);

                message.Subject = "Inquiry from BriEuton.com";
                var builder = new StringBuilder();
                builder.AppendLine(string.Format("Name: {0}", model.Name));
                builder.AppendLine(string.Format("Email: {0}", model.Email));
                builder.AppendLine(string.Format("Phone: {0}", model.Phone));
                builder.AppendLine(string.Format("Info: {0}", model.Info));
                message.Body = builder.ToString();

                var client = new SmtpClient("smtp.gmail.com", 587);           
                client.EnableSsl = true;
               
                client.Send(message);
            }
            catch (Exception ex)
            {
                
            }

        }

    }
}
