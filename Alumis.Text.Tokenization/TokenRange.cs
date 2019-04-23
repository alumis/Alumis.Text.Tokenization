using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Alumis.Text.Tokenization
{
    public struct TokenRange : IEnumerable<TokenNode>
    {
        public TokenNode Start, Tail;

        public TokenRange(TokenNode start, TokenNode tail)
        {
            Start = start;
            Tail = tail;
        }

        public IEnumerator<TokenNode> GetEnumerator()
        {
            for (var node = Start; node != Tail; node = node.Next)
                yield return node;
        }

        public override string ToString()
        {
            var parts = new List<string>();

            for (var node = Start; node != Tail; node = node.Next)
                parts.Add(node.Value.ToString());
                //parts.Add(node.Value.File.Substring(node.Value.Interval));

            return string.Join(" ", parts);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
