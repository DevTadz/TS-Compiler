using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS_Compiler.Lexer.Classes
{
    public class Lexer
    {
        char start_tok;
        char current_tok;
        TokenData? tokens;
        int lineNumber;
        char line_start;
        int token_count;
        int capacity;
    }
}
