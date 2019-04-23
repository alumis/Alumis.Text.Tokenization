using Alumis.Text.Unicode;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alumis.Text.Tokenization
{
    public class TokenizedText
    {
        public TokenizedText(GraphemeString graphemeString, TokenRange tokenRange)
        {
            GraphemeString = graphemeString;
            TokenRange = tokenRange;

            for (TokenNode start = tokenRange.Start, node = tokenRange.Start; ;)
            {
                if (node.Value.Type == TokenType.FullStop)
                {
                    for (node = node.Next; node.Value.Type == TokenType.FullStop; node = node.Next) ;
                    Sentences.Add(new TokenizedSentence(new TokenRange(start, node)));
                    start = node;
                    continue;
                }

                if (node.Value.Type == TokenType.Eof)
                {
                    if (start != node)
                        Sentences.Add(new TokenizedSentence(new TokenRange(start, node)));

                    break;
                }

                node = node.Next;
            }
        }

        public TokenizedText(GraphemeString graphemeString, string iso639Identifier = null) : this(graphemeString, Token.Tokenize(graphemeString, iso639Identifier))
        {
        }

        public GraphemeString GraphemeString;
        public TokenRange TokenRange;
        public List<TokenizedSentence> Sentences = new List<TokenizedSentence>();
    }
}
