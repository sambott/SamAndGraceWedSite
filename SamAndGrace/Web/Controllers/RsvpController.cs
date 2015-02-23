using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BotDetect.Web.UI.Mvc;
using Web.DAL;
using Web.Models;

namespace Web.Controllers
{
    public class RsvpController : Controller
    {
        private readonly RsvpRepository m_repo = new RsvpRepository();
        private readonly IEmailSender m_emailSender;

        public RsvpController()
        {
            m_emailSender = new EmailSender();
        }

        public RsvpController(IEmailSender emailSender)
        {
            m_emailSender = emailSender;
        }

        public ActionResult ViewRsvps()
        {
            return View(m_repo.GetAll().ToList());
        }

        public ActionResult Rsvpd()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CaptchaValidation("CaptchaCode", "SampleCaptcha", "Incorrect CAPTCHA code!")]
        public ActionResult Create([Bind(Include = "Name,Email,Attending,RequiresTransport,DietryRequirements")] Rsvp rsvp)
        {
            rsvp.RsvpdAt = DateTime.UtcNow;
            if (!ModelState.IsValid) return View(rsvp);

            m_repo.Add(rsvp);
            m_repo.Save();

            m_emailSender.SendEmail(
                new List<string> { "sam.bott@gmail.com" },
                "rsvp@samandgrace.org",
                string.Format("RSVP from {0}", rsvp.Name),
                string.Format("{0} has RSVP'd.\r\nSee http://www.samandgrace.org/Rsvp/ViewRsvps", rsvp.Name)
                );

            return RedirectToAction("Rsvpd");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                m_repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
