using System.Collections.Generic;

namespace Web.Controllers
{
    public interface IEmailSender
    {
        void SendEmail(IEnumerable<string> to, string subject, string body);
    }
}