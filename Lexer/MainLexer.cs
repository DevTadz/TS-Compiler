using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS_Compiler.Lexer
{
    public class MainLexer
    {
        // Filepath has to change, cant be like this. (Boilerplate)
        string filePath = "C:\\github repositories\\TS-Compiler\\TS-Script.txt";
        public char[] ReadCharactersInFile()
        {
            char[] characters = [];

            if(File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);

                foreach(char c in content)
                {
                    characters.Append(c);
                    Console.WriteLine(c);   
                }
            }

            return characters;
        }
        public void Lex()
        {

        }
    }
}
