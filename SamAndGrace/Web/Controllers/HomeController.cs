using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public static readonly DateTime WeddingDateTime = new DateTime(2015, 05, 03, 14, 30, 00).ToUniversalTime();

        public static DateTime WeddingDate
        {
            get
            {
                return WeddingDateTime.Date;
            }
        }

        public ActionResult Index()
        {
            ViewBag.DaysToGo = DaysTilWedding(DateTime.UtcNow);
            return View();
        }

        public ActionResult Itinerary()
        {
            return View();
        }

        public ActionResult GiftList()
        {
            return View();
        }

        public ActionResult Rsvp()
        {
            return View();
        }

        public ActionResult Taxis()
        {
            return View();
        }

        public ActionResult Hotels()
        {
            return View();
        }

        public ActionResult MusicSuggestions()
        {
            return View();
        }

        public static int DaysTilWedding(DateTime utcNow)
        {
            var weddingInterval = (WeddingDate - utcNow.Date).Days;
            return weddingInterval < 0 ? 0 : weddingInterval;
        }
    }
}