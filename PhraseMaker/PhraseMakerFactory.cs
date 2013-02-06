namespace PhraseMaker
{
    public class PhraseMakerFactory
    {
        public PhraseMaker Create(string dictionaryPath)
        {
            return new PhraseMaker(new FileBasedWordStore(dictionaryPath));
        }
    }
}