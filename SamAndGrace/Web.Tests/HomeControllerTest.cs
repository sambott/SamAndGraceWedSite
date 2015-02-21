using System.Collections.Generic;
using System.Web.Mvc;
using NUnit.Framework;
using Web.Controllers;
using Web.Models;

namespace Web.Tests
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void IndexExists()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void GiftListExists()
        {
            var controller = new HomeController();
            var result = controller.GiftList() as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void ItineraryExists()
        {
            var controller = new HomeController();
            var result = controller.Itinerary() as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void RsvpExists()
        {
            var controller = new HomeController();
            var result = controller.Rsvp() as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void MusicSuggestionsExists()
        {
            var controller = new HomeController();
            var result = controller.MusicSuggestions() as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void TaxisExists()
        {
            var controller = new HomeController();
            var result = controller.Taxis() as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void HotelsExists()
        {
            var controller = new HomeController();
            var result = controller.Hotels() as ViewResult;
            Assert.IsNotNull(result);
            Assert.That(result.ViewBag.Hotels, Is.TypeOf(typeof(List<Hotel>)));
            Assert.That(result.ViewBag.BAndBs, Is.TypeOf(typeof(List<BAndB>)));
        }

        [Test]
        public void DaysTilWeddingOnTheDayIsZero()
        {
            Assert.That(HomeController.DaysTilWedding(HomeController.WeddingDateTime), Is.EqualTo(0));
            Assert.That(HomeController.DaysTilWedding(HomeController.WeddingDate), Is.EqualTo(0));
        }

        [Test]
        public void BeforeTheWeddingItShouldShowDaysToGo()
        {
            Assert.That(HomeController.DaysTilWedding(HomeController.WeddingDateTime.AddDays(-1)), Is.EqualTo(1));
            Assert.That(HomeController.DaysTilWedding(HomeController.WeddingDate.AddMinutes(-1)), Is.EqualTo(1));
            Assert.That(HomeController.DaysTilWedding(HomeController.WeddingDateTime.AddDays(-5)), Is.EqualTo(5));
            Assert.That(HomeController.DaysTilWedding(HomeController.WeddingDateTime.AddDays(-80)), Is.EqualTo(80));
        }

        [Test]
        public void AfterWeddingItKeepsAtZero()
        {
            Assert.That(HomeController.DaysTilWedding(HomeController.WeddingDate.AddDays(1)), Is.EqualTo(0));
            Assert.That(HomeController.DaysTilWedding(HomeController.WeddingDateTime.AddDays(8)), Is.EqualTo(0));
        }
    }
}
