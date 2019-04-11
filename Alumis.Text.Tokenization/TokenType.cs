using System;
using System.Collections.Generic;
using System.Text;

namespace Alumis.Text.Tokenization
{
    public enum TokenType
    {
        Eof,

        Newline,
        Hex,
        Dec,

        OpeningBracket,
        ClosingBracket,
        OpeningParenthesis,
        ClosingParenthesis,
        OpeningBrace,
        ClosingBrace,
        FullStop,
        RightArrow,
        Underscore,

        Exponentiate,

        Plus,
        Minus,
        Not,

        Multiply,
        Divide,

        LessThan,
        GreaterThan,
        LessThanOrEqual,
        GreaterThanOrEqual,

        Equal,
        NotEqual,

        BitwiseAnd,

        BitwiseOr,

        ConditionalAnd,

        ConditionalOr,

        Assign,

        Comma,

        Colon,

        OtherPunctuation,

        Identifier,

        Emoji,
        Uri,
        Email
    }
}
