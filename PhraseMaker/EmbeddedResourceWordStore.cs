using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace PhraseMaker
{
    public class EmbeddedResourceWordStore : IStoreWords
    {
        private readonly Random _random = new Random();
        private Func<int, int, int> _randomizer;
        private readonly string[] _adjectives;
        private readonly string[] _nouns;


        public EmbeddedResourceWordStore(Assembly assembly, string @namespace)
        {
            _randomizer = (from, to) => _random.Next(from, to);

            _adjectives = GetResource(@namespace, assembly, "Adjectives.wrd");
            _nouns = GetResource(@namespace, assembly, "Nouns.wrd");
        }

        public string GetNoun()
        {
            return _nouns[_randomizer(0, _adjectives.Length - 1)];
        }

        public string GetAdjective()
        {
            return _adjectives[_randomizer(0, _adjectives.Length - 1)];
        }

        private static string[] GetResource(string @namespace, Assembly assembly, string fileName)
        {
            string[] result;
            using (var stream = assembly.GetManifestResourceStream(@namespace + "." + fileName))
            {
                if (stream == null)
                {
                    throw new ApplicationException("Cannot find resource \"" + fileName + "\" in namespace \"" + @namespace + "\"");
                }
                using (var streamReader = new StreamReader(stream))
                {
                    var elements = new List<string>();
                    while (streamReader.Peek() >= 0)
                    {
                        elements.Add(streamReader.ReadLine());
                    }
                    result = elements.ToArray();
                }
            }
            return result;
        }

        public Func<int, int, int> Randomizer
        {
            set { _randomizer = value; }
        }


    }
}