using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BotDetect.Web.UI.Mvc;
using Web.DAL;
using Web.Models;
using PagedList;

namespace Web.Controllers
{
    public class MusicSuggestionsController : Controller
    {
        private readonly ArtistRepository ar_repo = new ArtistRepository();
        private readonly TrackRepository tr_repo = new TrackRepository();

        public ActionResult ViewArtistSuggestions(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(ar_repo.GetAll().OrderByDescending(x => x.Votes).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ViewTrackSuggestions(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(tr_repo.GetAll().OrderByDescending(x => x.Votes).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult MusicSuggested()
        {
            return View();
        }

        public ActionResult SuggestMusic()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CaptchaValidation("CaptchaCode", "SampleCaptcha", "Incorrect CAPTCHA code!")]
        public ActionResult SuggestMusic([Bind(Include = "TrackName,ArtistName")] Track track)
        {
            if (!ModelState.IsValid) return View(track);
            Artist existingArtist = ar_repo.GetById(track.ArtistName);
            if (existingArtist != null)
            {
                existingArtist.CountVote();
                ar_repo.Edit(existingArtist);
            }
            else
            {
                Artist artist = new Artist();
                artist.ArtistName = track.ArtistName;
                ar_repo.Add(artist);
            }
            ar_repo.Save();

            Track existingTrack = tr_repo.GetById(track.TrackName, track.ArtistName);
            if (existingTrack != null)
            {
                existingTrack.CountVote();
                tr_repo.Edit(existingTrack);
            }
            else
            {
                tr_repo.Add(track);
            }
            tr_repo.Save();

            return RedirectToAction("MusicSuggested");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ar_repo.Dispose();
                tr_repo.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
