// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class StageTests
    {
        private Stage stage = null;
        private Performer performer = null;
        private Song song = null;
        [SetUp]
        public void Initial()
        {
            stage = new Stage();

            song = new Song("Detelini", new TimeSpan(1, 1, 0));
            performer = new Performer("Lili", "Ivanova", 20);
        }

        [Test]
        public void TestAddingNullPerformer()
        {
            Assert.Throws(typeof(ArgumentNullException), () => stage.AddPerformer(null));
        }

        [Test]
        public void TestAddingPerformerUnder18()
        {
            var performer = new Performer("Lili", "Ivanova", 16);

            Assert.Throws(typeof(ArgumentException), () => stage.AddPerformer(performer));
        }

        [Test]
        public void TestAddingPerformer()
        {
            stage.AddPerformer(performer);

            Assert.That(stage.Performers.Count, Is.EqualTo(1));
            Assert.That(stage.Performers.FirstOrDefault(s => s.FullName == performer.FullName), Is.EqualTo(performer));
        }

        [Test]
        public void TestAddingNullSong()
        {
            Assert.Throws(typeof(ArgumentNullException), () => stage.AddSong(null));
        }

        [Test]
        public void TestAddingSongUnder18()
        {
            var song = new Song("Detelini", new TimeSpan(0, 0, 1));

            Assert.Throws(typeof(ArgumentException), () => stage.AddSong(song));
        }


        [Test]
        public void SongMustNotBeNullSongToPerformer()
        {
            Assert.Throws(typeof(ArgumentNullException), () => stage.AddSongToPerformer(null, "Pesho"));
        }

        [Test]
        public void PerformerMustNotBeNullSongToPerformer()
        {
            Assert.Throws(typeof(ArgumentNullException), () => stage.AddSongToPerformer("Pesen1", null));
        }

        [Test]
        public void SongNotFoundAddSongToPerformer()
        {
            Assert.Throws(typeof(ArgumentException), () => stage.AddSongToPerformer("DeteliniNevalidni", "Lili Ivanova"));
        }

        [Test]
        public void PerformerNotFoundAddSongToPerformer()
        {
            Assert.Throws(typeof(ArgumentException), () => stage.AddSongToPerformer("Detelini", "Lili NeIvanova"));
        }


        [Test]
        public void PerformerMatchedSongToPerformer()
        {
            stage.AddPerformer(performer);
            stage.AddSong(song);

            stage.AddSongToPerformer("Detelini", "Lili Ivanova");

            Assert.That(stage.Performers.FirstOrDefault(s => s.FullName == performer.FullName), Is.EqualTo(performer));
        }

        [Test]
        public void SongAddedToPerformerSongToPerformer()
        {
            stage.AddPerformer(performer);
            stage.AddSong(song);

            stage.AddSongToPerformer("Detelini", "Lili Ivanova");

            Assert.That(stage.Performers.FirstOrDefault(s => s.FullName == performer.FullName).SongList[0], Is.EqualTo(song));
        }

        [Test]
        public void PlayReturnsRight()
        {
            stage.AddPerformer(performer);
            stage.AddSong(song);

            var song1 = new Song("Detelini12", new TimeSpan(1, 21, 0));
            var song2 = new Song("Detelini1", new TimeSpan(1, 2, 0));
           
            stage.AddSong(song1);
            stage.AddSong(song2);

            var performer1 = new Performer("Lili1", "Ivanova", 29);
           
            stage.AddPerformer(performer1);

            stage.AddSongToPerformer("Detelini12", "Lili Ivanova");
            stage.AddSongToPerformer("Detelini1", "Lili Ivanova");
            stage.AddSongToPerformer("Detelini", "Lili1 Ivanova");

            Assert.That(stage.Play(), Is.EqualTo($"2 performers played 3 songs"));
        }

        [Test]
        public void PerformerCannotBeNullMessage()
        {
            Assert.Throws(Is.TypeOf<ArgumentNullException>().And.Message.EqualTo("Can not be null! (Parameter 'performer')"), () => stage.AddPerformer(null));
        }
    }

}
