using System;
using System.Collections.Generic;

namespace Web.Controllers
{
    public class EmailSender : IEmailSender
    {
        public void SendEmail(IEnumerable<string> to, string @from, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}