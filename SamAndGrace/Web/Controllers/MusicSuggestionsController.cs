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
        private readonly EchoNestHelper enHelper = new EchoNestHelper();
        
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

        public ActionResult MusicSuggested(string trackName, string artistName)
        {
            ViewBag.TrackName = trackName;
            ViewBag.ArtistName = artistName;
            return View();
        }

        public ActionResult SuggestMusic()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CaptchaValidation("CaptchaCode", "SampleCaptcha", "Incorrect CAPTCHA code!")]
        public ActionResult SuggestMusic([Bind(Include = "TrackId,TrackName,ArtistId,ArtistName")] Track track)
        {
            if (!ModelState.IsValid) return View(track);
            Artist existingArtist = ar_repo.GetById(track.ArtistId);
            if (existingArtist != null)
            {
                existingArtist.CountVote();
                ar_repo.Edit(existingArtist);
            }
            else
            {
                Artist artist = new Artist();
                artist.ArtistId = track.ArtistId;
                artist.ArtistName = track.ArtistName;
                ar_repo.Add(artist);
            }
            ar_repo.Save();

            Track existingTrack = tr_repo.GetById(track.TrackId, track.ArtistId);
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

            return RedirectToAction("MusicSuggested", new { trackName=track.TrackName, artistName=track.ArtistName });
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

        public string GetEchoNestArtists(int results, string format, string name)
        {
            string sort = "&sort=familiarity-desc";
            string query = "v4/artist/search?" + "results=" + results + "&format=" + format + "&name=" + name + sort;
            return enHelper.MakeEchoNestRequest(query);
        }

        public string GetEchoNestTracks(int results, string format, string id, string start)
        {
            string query = "v4/artist/songs?" + "results=" + results + "&format=" + format + "&id=" + id + "&start=" + start; 
            return enHelper.MakeEchoNestRequest(query);
        }
    }
}
