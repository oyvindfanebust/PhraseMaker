using System;
using NUnit.Framework;

namespace PhraseMaker.Tests
{
    [TestFixture]
    public class FileBasedWordStoreTests
    {
        [Test]
        public void can_load_adjectives_from_file()
        {
            var wordStore = new FileBasedWordStore("no-nb") { Randomizer = (from, to) => 1 };

            string adjective = wordStore.GetAdjective();

            Assert.That(adjective, Is.EqualTo("flott"));
        }

        [Test]
        public void can_load_nouns_from_file()
        {
            var wordStore = new FileBasedWordStore("no-nb") { Randomizer = (from, to) => 1 };

            string noun = wordStore.GetNoun();

            Assert.That(noun, Is.EqualTo("pære"));
        }

        [Test]
        public void throws_if_missing_directory()
        {
            var exception = Assert.Throws<ApplicationException>(() => new FileBasedWordStore("no-nothing"));

            Assert.That(exception.Message, Is.EqualTo("Cannot find the directory \"no-nothing\""));
        }

        [Test]
        public void throws_if_missing_nouns_file()
        {
            var exception = Assert.Throws<ApplicationException>(() => new FileBasedWordStore("no-noun"));

            Assert.That(exception.Message, Is.EqualTo("Cannot find file \"Nouns.wrd\" in directory \"no-noun\""));
        }

        [Test]
        public void throws_if_missing_adjectives_file()
        {
            var exception = Assert.Throws<ApplicationException>(() => new FileBasedWordStore("no-adj"));

            Assert.That(exception.Message, Is.EqualTo("Cannot find file \"Adjectives.wrd\" in directory \"no-adj\""));
        }
    }
}