using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS_Compiler.Lexer.Enums
{
    public enum TokenType
    {
        Illegal,
        EOF,
        Ident,
        Int,
        Assign,
        Pluss,
        Comma,
        Semicolon,
        LParen,
        RParen,
        LBrace,
        RBrace,
        Function,
        Let
    }
}
