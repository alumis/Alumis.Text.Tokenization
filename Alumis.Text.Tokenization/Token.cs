using Alumis.Collections;
using Alumis.Text.Unicode;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Alumis.Text.Tokenization
{
    public class Token
    {
        public TokenType Type;
        public object Value;
        public TokenInterval Interval;

        public Token(TokenType type, object value, TokenInterval interval)
        {
            Type = type;
            Value = value;
            Interval = interval;
        }

        public override string ToString()
        {
            switch (Type)
            {
                case TokenType.Emoji:
                    return "<emoji>";
                case TokenType.Uri:
                    return $"<uri {(string)Value}>";
                case TokenType.Email:
                    return $"<email {(string)Value}>";
                case TokenType.Newline:
                    return "<newline>";
            }

            return Value.ToString();
        }

        static Regex _uriRegex = new Regex(@"((http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)", RegexOptions.IgnoreCase);
        static Regex _emailRegex = new Regex(@"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}", RegexOptions.IgnoreCase);

        public static TokenNode Tokenize(GraphemeString graphemeString)
        {
            var head = new TokenNode(new Token(TokenType.Eof, null, new TokenInterval(0, 0)));
            var prev = head;

            var enumerator = new GraphemeStringEnumerator(graphemeString);
            var i = 0;

            void AppendToken(TokenType type, object obj, int length = 1)
            {
                prev = prev.Next = new TokenNode(new Token(type, obj, new TokenInterval(i, i += length))) { Previous = prev };
            }

            var regexMatches = new Dictionary<int, (Match, TokenType)>();

            foreach (Match m in _emailRegex.Matches(graphemeString.Value))
                regexMatches[m.Index] = (m, TokenType.Email);

            foreach (Match m in _uriRegex.Matches(graphemeString.Value))
                regexMatches[m.Index] = (m, TokenType.Uri);

            while (enumerator.MoveNext())
            {
                if (enumerator.Current.IsNewlineGrapheme())
                {
                    AppendToken(TokenType.Newline, enumerator.Current);
                    continue;
                }

                if (regexMatches.TryGetValue(enumerator.CurrentUtf16Position, out (Match, TokenType) tuple))
                {
                    var j = i++;

                    for (var k = tuple.Item1.Length - 1; 0 < k; --k)
                    {
                        enumerator.MoveNext();
                        ++i;
                    }

                    prev = prev.Next = new TokenNode(new Token(tuple.Item2, tuple.Item1.Value, new TokenInterval(j, i))) { Previous = prev };
                    continue;
                }


                if (Emoji.EmoticonToEmojiIndex.TryGetValue(enumerator.Current, out (int CodePoint, bool IsPartial) entry))
                {
                    var position = enumerator.Position;
                    var current = enumerator.Current;
                    var j = i++;

                    int codePoint;

                    int k;

                    if (entry.CodePoint != 0)
                    {
                        codePoint = entry.CodePoint;
                        k = i;
                    }

                    else
                    {
                        codePoint = 0;
                        k = 0;
                    }

                    var str = enumerator.Current;

                    while (entry.IsPartial && enumerator.MoveNext())
                    {
                        ++i;

                        var test = str + enumerator.Current;

                        if (Emoji.EmoticonToEmojiIndex.TryGetValue(test, out entry))
                        {
                            if (entry.CodePoint != 0)
                            {
                                position = enumerator.Position;
                                codePoint = entry.CodePoint;
                                k = i;
                            }

                            if (!entry.IsPartial)
                                break;
                        }

                        else break;

                        str = test;
                    }

                    enumerator.Position = position;

                    if (codePoint != 0)
                    {
                        prev = prev.Next = new TokenNode(new Token(TokenType.Emoji, codePoint, new TokenInterval(j, i = k))) { Previous = prev };
                        continue;
                    }

                    else
                    {
                        enumerator.Current = current;
                        i = j;
                    }
                }

                if (enumerator.Current.Length == 1 && Emoji.Emojis.Contains(enumerator.Current[0]))
                {
                    AppendToken(TokenType.Emoji, (int)enumerator.Current[0]);
                    continue;
                }

                if (enumerator.Current.Length == 2 && char.IsHighSurrogate(enumerator.Current[0]) && char.IsLowSurrogate(enumerator.Current[1]))
                {
                    var codePoint = char.ConvertToUtf32(enumerator.Current[0], enumerator.Current[1]);

                    if (Emoji.Emojis.Contains(codePoint))
                    {
                        AppendToken(TokenType.Emoji, codePoint);
                        continue;
                    }
                }

                switch (enumerator.Current)
                {
                    case "0":
                        {
                            var position = enumerator.Position;

                            if (enumerator.MoveNext() && enumerator.Current == "x" && enumerator.MoveNext() && enumerator.Current.IsHexGrapheme())
                            {
                                var j = i;

                                i += 3;

                                position = enumerator.Position;

                                for (; enumerator.MoveNext() && enumerator.Current.IsHexGrapheme(); ++i)
                                    position = enumerator.Position;

                                enumerator.Position = position;
                                prev = prev.Next = new TokenNode(new Token(TokenType.Hex, graphemeString.NativeSubstring(j, i - j), new TokenInterval(j, i))) { Previous = prev };

                                continue;
                            }

                            enumerator.Position = position;
                        }

                        goto case "1";

                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                        {
                            var j = i++;
                            var position = enumerator.Position;
                            var hasFractionalPart = false;
                            var hasExponent = false;

                            while (enumerator.MoveNext())
                            {
                                if (enumerator.Current.IsDecGrapheme())
                                {
                                    position = enumerator.Position;
                                    ++i;

                                    continue;
                                }

                                else if (enumerator.Current == " " || enumerator.Current == "\u2009")
                                {
                                    if (enumerator.MoveNext() && enumerator.Current.IsDecGrapheme())
                                    {
                                        position = enumerator.Position;
                                        i += 2;

                                        continue;
                                    }
                                }

                                else if (enumerator.Current == "." || enumerator.Current == ",")
                                {
                                    if (!hasFractionalPart && !hasExponent && enumerator.MoveNext() && enumerator.Current.IsDecGrapheme())
                                    {
                                        position = enumerator.Position;
                                        i += 2;
                                        hasFractionalPart = true;

                                        continue;
                                    }
                                }

                                else if (!hasExponent && (enumerator.Current == "e" || enumerator.Current == "E"))
                                {
                                    if (enumerator.MoveNext())
                                    {
                                        if (enumerator.Current.IsDecGrapheme())
                                        {
                                            position = enumerator.Position;
                                            i += 2;
                                            hasExponent = true;

                                            continue;
                                        }

                                        if ((enumerator.Current == "+" || enumerator.Current == "-" || enumerator.Current == "\u2212") && enumerator.MoveNext() && enumerator.Current.IsDecGrapheme())
                                        {
                                            position = enumerator.Position;
                                            i += 3;
                                            hasExponent = true;

                                            continue;
                                        }
                                    }
                                }

                                break;
                            }

                            enumerator.Position = position;
                            prev = prev.Next = new TokenNode(new Token(TokenType.Dec, graphemeString.NativeSubstring(j, i - j), new TokenInterval(j, i))) { Previous = prev };

                            continue;
                        }

                    case "[":
                        AppendToken(TokenType.OpeningBracket, "[");
                        continue;
                    case "]":
                        AppendToken(TokenType.ClosingBracket, "]");
                        continue;
                    case "(":
                        AppendToken(TokenType.OpeningParenthesis, "(");
                        continue;
                    case ")":
                        AppendToken(TokenType.ClosingParenthesis, ")");
                        continue;
                    case "{":
                        AppendToken(TokenType.OpeningBrace, "{");
                        continue;
                    case "}":
                        AppendToken(TokenType.ClosingBrace, "}");
                        continue;
                    case ".":
                        AppendToken(TokenType.FullStop, ".");
                        continue;
                    case "-":
                        {
                            var position = enumerator.Position;

                            if (enumerator.MoveNext() && enumerator.Current == ">")
                            {
                                AppendToken(TokenType.RightArrow, "->", 2);
                                continue;
                            }

                            enumerator.Position = position;
                            AppendToken(TokenType.Minus, "-");

                            continue;
                        }
                    case "→":
                        AppendToken(TokenType.RightArrow, "→");
                        continue;
                    case "_":
                        AppendToken(TokenType.Underscore, "_");
                        continue;

                    case "^":
                        AppendToken(TokenType.Exponentiate, "^");
                        continue;

                    case "+":
                        AppendToken(TokenType.Plus, "+");
                        continue;
                    case "\u2212":
                        AppendToken(TokenType.Minus, "\u2212");
                        continue;
                    case "!":
                        {
                            var position = enumerator.Position;

                            if (enumerator.MoveNext() && enumerator.Current == "=")
                            {
                                AppendToken(TokenType.NotEqual, "!=", 2);
                                continue;
                            }

                            enumerator.Position = position;
                            AppendToken(TokenType.Not, "!");
                            continue;
                        }
                    case "¬":
                        AppendToken(TokenType.Not, "¬");
                        continue;

                    case "*":
                    case "×":
                        AppendToken(TokenType.Multiply, enumerator.Current);
                        continue;
                    case "/":
                    case "÷":
                        AppendToken(TokenType.Divide, enumerator.Current);
                        continue;

                    case "<":
                        {
                            var position = enumerator.Position;

                            if (enumerator.MoveNext() && enumerator.Current == "=")
                            {
                                AppendToken(TokenType.LessThanOrEqual, "<=", 2);
                                continue;
                            }

                            enumerator.Position = position;
                            AppendToken(TokenType.LessThan, "<");

                            continue;
                        }
                    case ">":
                        {
                            var position = enumerator.Position;

                            if (enumerator.MoveNext() && enumerator.Current == "=")
                            {
                                AppendToken(TokenType.GreaterThanOrEqual, ">=", 2);
                                continue;
                            }

                            enumerator.Position = position;
                            AppendToken(TokenType.GreaterThan, ">");

                            continue;
                        }
                    case "≤":
                        AppendToken(TokenType.LessThanOrEqual, "≤");
                        continue;
                    case "≥":
                        AppendToken(TokenType.GreaterThanOrEqual, "≥");
                        continue;

                    case "=":
                        {
                            var position = enumerator.Position;

                            if (enumerator.MoveNext())
                            {
                                if (enumerator.Current == "=")
                                {
                                    AppendToken(TokenType.Equal, "==", 2);
                                    continue;
                                }

                                if (enumerator.Current == "<")
                                {
                                    AppendToken(TokenType.LessThanOrEqual, "=<", 2);
                                    continue;
                                }

                                if (enumerator.Current == ">")
                                {
                                    AppendToken(TokenType.GreaterThanOrEqual, "=>", 2);
                                    continue;
                                }
                            }

                            enumerator.Position = position;
                            AppendToken(TokenType.Assign, "=");

                            continue;
                        }

                    case "&":
                        {
                            var position = enumerator.Position;

                            if (enumerator.MoveNext() && enumerator.Current == "&")
                            {
                                AppendToken(TokenType.ConditionalAnd, "&&", 2);
                                continue;
                            }

                            enumerator.Position = position;
                            AppendToken(TokenType.BitwiseAnd, "&");

                            continue;
                        }

                    case "|":
                        {
                            var position = enumerator.Position;

                            if (enumerator.MoveNext() && enumerator.Current == "|")
                            {
                                AppendToken(TokenType.ConditionalOr, "||", 2);
                                continue;
                            }

                            enumerator.Position = position;
                            AppendToken(TokenType.BitwiseOr, "|");

                            continue;
                        }

                    case "∧":
                        AppendToken(TokenType.ConditionalAnd, "∧");
                        continue;

                    case "∨":
                        AppendToken(TokenType.ConditionalOr, "∨");
                        continue;

                    case ",":
                        AppendToken(TokenType.Comma, ",");
                        continue;

                    case ":":
                        AppendToken(TokenType.Colon, ":");
                        continue;

                    default:

                        if (enumerator.Current.Length == 1 && char.IsPunctuation(enumerator.Current[0]))
                        {
                            AppendToken(TokenType.OtherPunctuation, enumerator.Current);
                            continue;
                        }

                        break;
                }

                if (enumerator.Current.LastCodePoint().HasBinaryPropertyXidStart())
                {
                    var j = i++;
                    var position = enumerator.Position;

                    for (; enumerator.MoveNext() && enumerator.Current.LastCodePoint().HasBinaryPropertyXidContinue(); ++i)
                        position = enumerator.Position;

                    enumerator.Position = position;
                    prev = prev.Next = new TokenNode(new Token(TokenType.Identifier, graphemeString.NativeSubstring(j, i - j), new TokenInterval(j, i))) { Previous = prev };

                    continue;
                }

                if (enumerator.Current.IsWhitespaceGrapheme())
                {
                    ++i;
                    continue;
                }

                prev = prev.Next = new TokenNode(new Token(TokenType.Identifier, enumerator.Current, new TokenInterval(i, ++i))) { Previous = prev };
            }

            prev.Next = new TokenNode(new Token(TokenType.Eof, null, new TokenInterval(i, 0))) { Previous = prev };

            return head;
        }
    }
}
