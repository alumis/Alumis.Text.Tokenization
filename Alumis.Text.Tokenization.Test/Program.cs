using Alumis.Text.Unicode;
using System;

namespace Alumis.Text.Tokenization.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = new TokenizedText("☹️", "nor");

            foreach (var s in text.Sentences)
            {
                Console.WriteLine("SENTENCE");

                foreach (var n in s.TokenRange)
                    Console.WriteLine(text.GraphemeString.Substring(n.Value.Interval.Index, n.Value.Interval.Length));
            }

            Console.Read();
        }
    }
}
