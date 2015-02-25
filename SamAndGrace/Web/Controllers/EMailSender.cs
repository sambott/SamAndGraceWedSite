using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using SendGrid;
using WebGrease.Css.Extensions;

namespace Web.Controllers
{
    internal class EmailSender : IEmailSender
    {
        private readonly NetworkCredential m_credentials;

        public EmailSender()
        {
            string username = Environment.GetEnvironmentVariable("SENDGRID_USER");
            string password = Environment.GetEnvironmentVariable("SENDGRID_PASS");
            m_credentials = new NetworkCredential(username, password);
        }


        public void SendEmail(IEnumerable<string> to, string subject, string body)
        {
            var email = new SendGridMessage();
            to.ForEach(email.AddTo);
            email.From = new MailAddress("sam@samandgrace.org", "Sam Bott");
            email.Subject = subject;
            email.Text = body;

            email.EnableClickTracking(true);
            var transportWeb = new SendGrid.Web(m_credentials);
            transportWeb.Deliver(email);
        }
    }
}