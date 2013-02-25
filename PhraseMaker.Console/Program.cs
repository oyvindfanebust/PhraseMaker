using System;

namespace PhraseMaker.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 1)
            {
                System.Console.WriteLine("Please supply a path to a word-store");
                return;
            }

            var factory = new PhraseMakerFactory();
            var path = args[0];
            var phraseMaker = factory.Create(path);
            System.Console.WriteLine("Press 'q' to exit.");
            ConsoleKeyInfo key = System.Console.ReadKey();
            while(key.KeyChar != 'q')
            {
                System.Console.WriteLine(phraseMaker.GeneratePhrase());
                key = System.Console.ReadKey();
            }
            
        }
    }
}
