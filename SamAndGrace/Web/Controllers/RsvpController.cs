using System.Linq;
using System.Net;
using System.Web.Mvc;
using BotDetect.Web.UI.Mvc;
using Web.DAL;
using Web.Models;

namespace Web.Controllers
{
    public class RsvpController : Controller
    {
        private readonly RsvpRepository m_repo = new RsvpRepository();

        // GET: Rsvp
        public ActionResult Index()
        {
            return View(m_repo.GetAll().ToList());
        }

        // GET: Rsvp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rsvp rsvp = m_repo.GetById(id.Value);
            if (rsvp == null)
            {
                return HttpNotFound();
            }
            return View(rsvp);
        }

        // GET: Rsvp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rsvp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CaptchaValidation("CaptchaCode", "SampleCaptcha", "Incorrect CAPTCHA code!")]
        public ActionResult Create([Bind(Include = "Id,Name,Attending,RequiresTransport,DietryRequirements")] Rsvp rsvp)
        {
            if (ModelState.IsValid)
            {
                m_repo.Add(rsvp);
                m_repo.Save();
                return RedirectToAction("Index");
            }

            return View(rsvp);
        }

        // GET: Rsvp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rsvp rsvp = m_repo.GetById(id.Value);
            if (rsvp == null)
            {
                return HttpNotFound();
            }
            return View(rsvp);
        }

        // POST: Rsvp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Attending,RequiresTransport,DietryRequirements")] Rsvp rsvp)
        {
            if (ModelState.IsValid)
            {
                m_repo.Edit(rsvp);
                m_repo.Save();
                return RedirectToAction("Index");
            }
            return View(rsvp);
        }

        // GET: Rsvp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rsvp rsvp = m_repo.GetById(id.Value);
            if (rsvp == null)
            {
                return HttpNotFound();
            }
            return View(rsvp);
        }

        // POST: Rsvp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rsvp rsvp = m_repo.GetById(id);
            m_repo.Delete(rsvp);
            m_repo.Save();
            return RedirectToAction("Index");
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
