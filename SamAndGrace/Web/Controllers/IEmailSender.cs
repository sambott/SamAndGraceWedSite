using System.Collections.Generic;

namespace Web.Controllers
{
    public interface IEmailSender
    {
        void SendEmail(IEnumerable<string> to, string from, string subject, string body);
    }
}