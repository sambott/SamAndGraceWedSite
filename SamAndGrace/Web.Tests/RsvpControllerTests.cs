using System.Linq;
using System.Web.Mvc;
using NUnit.Framework;
using Web.Controllers;
using Web.DAL;
using Web.Models;

namespace Web.Tests.Controllers
{
    [TestFixture]
    public class RsvpControllerTests
    {
        [Test]
        public void ViewRsvpsExists()
        {
            var controller = new RsvpController();
            var result = controller.ViewRsvps() as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void RsvpdViewExists()
        {
            var controller = new RsvpController();
            var result = controller.Rsvpd() as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void CreateExists()
        {
            var controller = new RsvpController();
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void CreateAddsRsvp()
        {
            var repo = new RsvpRepository();
            repo.GetAll().ToList().ForEach(repo.Delete);
            repo.Save();

            var controller = new RsvpController();
            controller.Create(new Rsvp
            {
                Attending = true,
                DietryRequirements = "nothing",
                Email = "abc123@somewhere.com",
                Name = "name",
                RequiresTransport = false
            });
            Assert.That(repo.GetAll().Count(), Is.EqualTo(1));
        }
    }
}
