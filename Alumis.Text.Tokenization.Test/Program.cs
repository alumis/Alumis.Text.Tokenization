using Alumis.Text.Unicode;
using System;

namespace Alumis.Text.Tokenization.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = new TokenizedText("this is a test. and this is a test.");

            foreach (var s in text.Sentences)
            {
                var startIndex = s.Head.Next.Value.Interval.Index;
                var endIndex = s.Tail.Previous.Value.Interval.IndexUpper;

                Console.WriteLine(text.GraphemeString.Substring(startIndex, endIndex - startIndex));
            }

            Console.Read();
        }
    }
}
