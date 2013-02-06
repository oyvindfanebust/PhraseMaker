namespace PhraseMaker
{
    public class PhraseMaker
    {
        private IStoreWords _wordStore;

        public IStoreWords WordStore
        {
            set { _wordStore = value; }
        }

        public string GeneratePhrase()
        {
            return string.Format("{0} {1}", _wordStore.GetAdjective(), _wordStore.GetNoun());
        }
    }
}
