using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Web.Controllers;
using Web.DAL;
using Web.Models;

namespace Web.Tests
{
    [TestFixture]
    public class MusicSuggestionsControllerTests
    {
        private ArtistRepository a_repo;
        private TrackRepository t_repo;

        public MusicSuggestionsControllerTests()
        {
            a_repo = new ArtistRepository();
            t_repo = new TrackRepository();
        }

        [SetUp]
        public void Setup()
        {
            a_repo.GetAll().ToList().ForEach(a_repo.Delete);
            a_repo.Save();
            t_repo.GetAll().ToList().ForEach(t_repo.Delete);
            t_repo.Save();
        }

        [Test]
        public void SuggestMusicExists()
        {
            MusicSuggestionsController controller = new MusicSuggestionsController();
            ViewResult result = controller.SuggestMusic() as ViewResult;
        }

        [Test]
        public void ViewArtistSuggestionsExists()
        {
            MusicSuggestionsController controller = new MusicSuggestionsController();
            ViewResult result = controller.ViewArtistSuggestions(1) as ViewResult;
        }

        [Test]
        public void ViewTrackSuggestionsExists()
        {
            MusicSuggestionsController controller = new MusicSuggestionsController();
            ViewResult result = controller.ViewTrackSuggestions(1) as ViewResult;
        }

        [Test]
        public void MusicSuggestedExists()
        {
            MusicSuggestionsController controller = new MusicSuggestionsController();
            ViewResult result = controller.MusicSuggested() as ViewResult;
        }

        [Test]
        public void SuggestMusicAddsSuggestion()
        {
            var controller = new MusicSuggestionsController();
            controller.SuggestMusic(new Track
            {
                TrackName = "track 1",
                ArtistName = "artist 1"
            });
            Assert.That(t_repo.GetAll().Count(), Is.EqualTo(1));
            Assert.That(a_repo.GetAll().Count(), Is.EqualTo(1));
        }

        [Test]
        public void SuggestTwoTracksOneArtistCountsVotes()
        {
            var controller = new MusicSuggestionsController();
            controller.SuggestMusic(new Track
            {
                TrackName = "track 1",
                ArtistName = "artist 1"
            });
            controller.SuggestMusic(new Track
            {
                TrackName = "track 2",
                ArtistName = "artist 1"
            });
            Assert.That(t_repo.GetAll().Count(), Is.EqualTo(2));
            Assert.That(a_repo.GetAll().Count(), Is.EqualTo(1));
            Assert.That(a_repo.GetById("artist 1").Votes, Is.EqualTo(2));
            Assert.That(t_repo.GetById("track 1", "artist 1").Votes, Is.EqualTo(1));
            Assert.That(t_repo.GetById("track 2", "artist 1").Votes, Is.EqualTo(1));
        }
    }
}
