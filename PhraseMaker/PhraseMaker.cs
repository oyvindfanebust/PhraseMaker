namespace PhraseMaker
{
    public class PhraseMaker
    {
        private readonly IStoreWords _wordStore;

        public PhraseMaker(IStoreWords wordStore)
        {
            _wordStore = wordStore;
        }

        public string GeneratePhrase()
        {
            return string.Format("{0} {1}", _wordStore.GetAdjective(), _wordStore.GetNoun());
        }
    }
}
