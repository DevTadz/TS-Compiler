using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS_Compiler.Lexer.Enums;

namespace TS_Compiler.Lexer.Classes
{
    public class TokenData
    {
        public required TokenType Type;
        public required char val;
        public required Location location;
    }
}
