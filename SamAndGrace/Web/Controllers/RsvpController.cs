﻿using System.Linq;
using System.Web.Mvc;
using BotDetect.Web.UI.Mvc;
using Web.DAL;
using Web.Models;

namespace Web.Controllers
{
    public class RsvpController : Controller
    {
        private readonly RsvpRepository m_repo = new RsvpRepository();

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
        public ActionResult Create([Bind(Include = "Id,Name,Attending,RequiresTransport,DietryRequirements")] Rsvp rsvp)
        {
            if (ModelState.IsValid)
            {
                m_repo.Add(rsvp);
                m_repo.Save();
                return RedirectToAction("Rsvpd");
            }

            return View(rsvp);
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