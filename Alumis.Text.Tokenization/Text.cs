using Alumis.Text.Unicode;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alumis.Text.Tokenization
{
    public class Text
    {
        public Text(GraphemeString graphemeString)
        {
            var head = Head = Token.Tokenize(GraphemeString = graphemeString);

            for (var node = head.Next; ;)
            {
                if (node.Value.Type == TokenType.FullStop)
                {
                    for (node = node.Next; node.Value.Type == TokenType.FullStop; node = node.Next) ;
                    Sentences.Add(new TokenizedSentence(head, node));
                    head = node.Previous;
                    continue;
                }

                if (node.Value.Type == TokenType.Eof)
                {
                    if (head.Next != node)
                        Sentences.Add(new TokenizedSentence(head, node));

                    break;
                }

                node = node.Next;
            }
        }

        public GraphemeString GraphemeString;
        public TokenNode Head;
        public List<TokenizedSentence> Sentences = new List<TokenizedSentence>();
    }
}
