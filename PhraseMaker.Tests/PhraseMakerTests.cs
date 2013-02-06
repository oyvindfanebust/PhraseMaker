using NUnit.Framework;

namespace PhraseMaker.Tests
{
    [TestFixture]
    public class PhraseMakerTests
    {
        [Test]
        public void can_generate_phrase_with_adjective_and_noun()
        {
            var wordStore = new FakeWordStore
                {
                    Adjective = "grønn",
                    Noun = "banan"
                };

            var phraseMaker = new PhraseMaker(wordStore);

            var phrase = phraseMaker.GeneratePhrase();

            Assert.That(phrase, Is.EqualTo("grønn banan"));
        }
    }

    public class FakeWordStore : IStoreWords
    {
        public string Noun;
        public string Adjective;

        public string GetNoun()
        {
            return Noun;
        }

        public string GetAdjective()
        {
            return Adjective;
        }
    }

}
