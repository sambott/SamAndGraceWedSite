using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Web.Controllers;
using Web.DAL;
using Web.Models;

namespace Web.Tests
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

            var mockEmailSender = new Mock<IEmailSender>();

            string message = null;
            string subject = null;
            mockEmailSender.Setup(
                m =>
                    m.SendEmail(It.IsAny<IEnumerable<string>>(), It.IsAny<string>(), It.IsAny<string>(),
                        It.IsAny<string>()))
                .Callback<IEnumerable<string>,string,string,string>((t, f, s, b) =>
                {
                    message = b;
                    subject = s;
                });

            var controller = new RsvpController(mockEmailSender.Object);
            controller.Create(new Rsvp
            {
                Attending = true,
                DietryRequirements = "nothing",
                Email = "abc123@somewhere.com",
                Name = "name",
                RequiresTransport = false
            });

            Assert.That(repo.GetAll().Count(), Is.EqualTo(1));
            Assert.That(message, Is.EqualTo("name has RSVP'd.\r\nSee http://www.samandgrace.org/Rsvp/ViewRsvps"));
            Assert.That(subject, Is.EqualTo("RSVP from name"));
        }
    }
}
