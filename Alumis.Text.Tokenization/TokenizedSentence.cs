using System;
using System.Collections.Generic;
using System.Text;

namespace Alumis.Text.Tokenization
{
    public class TokenizedSentence
    {
        public TokenizedSentence(TokenRange tokenRange)
        {
            TokenRange = tokenRange;
        }

        public TokenRange TokenRange;
    }
}
