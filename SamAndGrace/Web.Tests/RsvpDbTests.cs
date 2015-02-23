using System;
using System.Linq;
using NUnit.Framework;
using Web.DAL;
using Web.Models;

namespace Web.Tests
{
    [TestFixture]
    public class RsvpDbTests
    {
        private readonly RsvpRepository m_repository;

        public RsvpDbTests()
        {
            m_repository = new RsvpRepository();
        }

        [SetUp]
        public void ClearDb()
        {
            foreach (var rsvp in m_repository.GetAll())
            {
                m_repository.Delete(rsvp);
            }
            m_repository.Save();
        }

        [Test]
        public void Test()
        {
            m_repository.Add(new Rsvp
            {
                Attending = true,
                Name = "Sam",
                RequiresTransport = false,
                Email = "sam@me.name",
                RsvpdAt = DateTime.UtcNow
            });
            m_repository.Save();
            Assert.That(m_repository.GetAll().Count(), Is.EqualTo(1));
        }
    }
}
