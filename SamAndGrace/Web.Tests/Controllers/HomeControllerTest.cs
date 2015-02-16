using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using Web;
using Web.Controllers;

namespace Web.Tests.Controllers
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
        public void ItineryExists()
        {
            var controller = new HomeController();
            var result = controller.Itinery() as ViewResult;
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

    }
}
