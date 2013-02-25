using NUnit.Framework;

namespace PhraseMaker.Tests
{
    [TestFixture]
    public class PhraseMakerFactoryTests
    {
        [Test]
        public void can_create_phrase_maker_with_file_store()
        {
            var factory = new PhraseMakerFactory();

            var phraseMaker = factory.Create("no-nb");

            string phrase = phraseMaker.GeneratePhrase();

            Assert.That(phrase, Is.Not.Null);
        }
    }
}