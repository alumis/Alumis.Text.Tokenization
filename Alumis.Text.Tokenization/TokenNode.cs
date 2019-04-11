using System;
using System.Collections.Generic;
using System.Text;

namespace Alumis.Text.Tokenization
{
    public class TokenNode
    {
        public Token Value;
        public TokenNode Previous, Next;

        public TokenNode(Token value)
        {
            Value = value;
        }

        public TokenNode(Token value, TokenNode previous)
        {
            Value = value;
            Previous = previous;
        }

        public override string ToString()
        {
            return Value?.ToString();
        }
    }
}
