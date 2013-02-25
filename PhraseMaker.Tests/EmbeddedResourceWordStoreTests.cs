using System;
using NUnit.Framework;

namespace PhraseMaker.Tests
{
    [TestFixture]
    public class EmbeddedResourceWordStoreTests
    {
        [Test]
        public void can_load_adjectives()
        {
            var wordStore = new EmbeddedResourceWordStore("PhraseMaker.Tests.Embedded") { Randomizer = (from, to) => 1 };

            string adjective = wordStore.GetAdjective();

            Assert.That(adjective, Is.EqualTo("flott"));
        }

        [Test]
        public void can_load_nouns()
        {
            var wordStore = new EmbeddedResourceWordStore("PhraseMaker.Tests.Embedded") { Randomizer = (from, to) => 1 };

            string noun = wordStore.GetNoun();

            Assert.That(noun, Is.EqualTo("pære"));
        }

        [Test]
        public void throws_if_missing_nouns_file()
        {
            var exception = Assert.Throws<ApplicationException>(() => new EmbeddedResourceWordStore("PhraseMaker.Tests.Embedded.NoNoun"));

            Assert.That(exception.Message, Is.EqualTo("Cannot find resource \"Nouns.wrd\" in namespace \"PhraseMaker.Tests.Embedded.NoNoun\""));
        }

        [Test]
        public void throws_if_missing_adjectives_file()
        {
            var exception = Assert.Throws<ApplicationException>(() => new EmbeddedResourceWordStore("PhraseMaker.Tests.Embedded.NoAdjective"));

            Assert.That(exception.Message, Is.EqualTo("Cannot find resource \"Adjectives.wrd\" in namespace \"PhraseMaker.Tests.Embedded.NoAdjective\""));
        }
    }
}