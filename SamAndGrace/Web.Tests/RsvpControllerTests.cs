using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Web.DAL;
using Web.Models;

namespace Web.Tests
{
    [TestFixture]
    public class RsvpControllerTests
    {
        private readonly RsvpRepository m_repository;

        public RsvpControllerTests()
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
            var t = new RsvpRepository();
            t.Add(new Rsvp
            {
                Attending = true,
                Name = "Sam",
                RequiresTransport = false
            });
            t.Save();
            Assert.That(t.GetAll().Count(), Is.EqualTo(1));
        }
    }
}
