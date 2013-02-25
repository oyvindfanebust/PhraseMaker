using System.Reflection;

namespace PhraseMaker
{
    public class PhraseMakerFactory
    {
        public IMakePhrases Create(string dictionaryPath)
        {
            return new PhraseMaker(new FileBasedWordStore(dictionaryPath));
        }
        
        public IMakePhrases Create(Assembly assembly, string @namespace)
        {
            return new PhraseMaker(new EmbeddedResourceWordStore(assembly, @namespace));
        }
    }
}