using System;
using System.IO;

namespace PhraseMaker
{
    public class FileBasedWordStore : IStoreWords
    {
        private readonly Random _random = new Random();
        private Func<int, int, int> _randomizer;
        private readonly string[] _adjectives;
        private readonly string[] _nouns;

        public FileBasedWordStore(string directory)
        {
            _randomizer = (from, to) => _random.Next(from, to);

            AssertExists(directory);
            AssertExists(directory, "Adjectives.wrd");
            AssertExists(directory, "Nouns.wrd");

            _adjectives = File.ReadAllLines(Path.Combine(directory, "Adjectives.wrd"));
            _nouns = File.ReadAllLines(Path.Combine(directory, "Nouns.wrd"));
        }

        private static void AssertExists(string type)
        {
            if (!Directory.Exists(type))
                throw new ApplicationException(string.Format(@"Cannot find the directory ""{0}""", type));
        }

        private static void AssertExists(string type, string file)
        {
            const string errorMessage = @"Cannot find file ""{0}"" in directory ""{1}""";

            if (!File.Exists(Path.Combine(type, file)))
            {
                throw new ApplicationException(string.Format(errorMessage, file, type));
            }
        }

        public Func<int, int, int> Randomizer
        {
            set { _randomizer = value; }
        }

        public string GetNoun()
        {
            return _nouns[_randomizer(0, _adjectives.Length - 1)];
        }

        public string GetAdjective()
        {
            return _adjectives[_randomizer(0, _adjectives.Length - 1)];
        }
    }
}