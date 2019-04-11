using System;
using System.Collections.Generic;
using System.Text;

namespace Alumis.Text.Tokenization
{
    public class TokenizedSentence
    {
        public TokenizedSentence(TokenNode head, TokenNode tail)
        {
            Head = head;
            Tail = tail;
        }

        public TokenNode Head, Tail;
    }
}
