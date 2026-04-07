using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS_Compiler.Lexer.Classes
{
    public class Lexer
    {
        public char start_tok;
        public char current_tok;
        public TokenData? tokens;
        public int lineNumber;
        public char line_start;
        public int token_count;
        public int capacity;
    }
}
