using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS_Compiler.Lexer.Classes;
using TS_Compiler.Lexer.Enums;

namespace TS_Compiler.Lexer
{
    public class MainLexer
    {
        string filePath = "C:\\github repositories\\TS-Compiler\\TS-Script.txt";

        Dictionary<string, TokenType> keywords = new()
        {
            { "let", TokenType.Let }
        };

        Dictionary<string, TokenType> operators = new()
        {
            { "=", TokenType.Equals }
        };
        public List<char> ReadCharactersInFile()
        {
            List<char> characters = new List<char>();

            if(File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);

                foreach(char c in content)
                {
                    characters.Add(c);
                }
            }
            else
            {
                Console.WriteLine("Error, couldnt find file");
            }

            return characters;
        }
        public void Lex()
        {
            List<char> characters = ReadCharactersInFile();
            List<TokenData> tokens = new List<TokenData>();

            int i = 0;
            var location = new Location();
            location.Col = 0;
            location.Line = 1;

            while (i < characters.Count)
            {
                char c = characters[i];
                var token = new TokenData();

                if (c == '"') // String Value
                {
                    i++; // To skip opening quote
                    location.Col++;
                    var sb_stringVal = new StringBuilder(); // use stringbuilder for performance

                    while (i < characters.Count && characters[i] != '"')
                    {
                        sb_stringVal.Append(characters[i]);// Populate stringVal with "..."
                        i++;
                        location.Col++;
                    }

                    // EOF protection. Case: "hello
                    if (i >= characters.Count)
                    {
                        throw new Exception("Unterminated string literal");
                    }

                    string stringVal = sb_stringVal.ToString();     

                    token.val = stringVal;  
                    token.location = new Location
                    {
                        Line = location.Line,
                        Col = location.Col
                    };
                    token.Type = TokenType.String;

                    location.Col += stringVal.Length;

                    tokens.Add(token);
                }
                else if(char.IsLetter(c)) // Either Identifier or Keyword
                {
                    var sb_identifier = new StringBuilder();

                    while (i < characters.Count && !char.IsWhiteSpace(characters[i]) && char.IsLetterOrDigit(characters[i])) // Read until space or special character
                    {
                        sb_identifier.Append(characters[i]);
                        i++;
                        location.Col++;
                    }
                    i -= 1;

                    string identifier = sb_identifier.ToString().ToLower();  
                    
                    if(keywords.ContainsKey(identifier)) // Keyword
                    {
                        var type = keywords[identifier];    

                        token.val = identifier;
                        token.location = new Location
                        {
                            Line = location.Line,
                            Col = location.Col
                        };
                        token.Type = type;
                    }
                    else // Identifier
                    {
                        token.val = identifier;
                        token.location = new Location
                        {
                            Line = location.Line,
                            Col = location.Col
                        }; ;
                        token.Type = TokenType.Identifier;
                    }

                    location.Col += identifier.Length;

                    tokens.Add(token);
                }
                else if(!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c)) // operator, dot or semi
                {
                    if(operators.ContainsKey(c.ToString()))
                    {
                        var type = operators[c.ToString()];

                        token.val = c.ToString();
                        token.location = new Location
                        {
                            Line = location.Line,
                            Col = location.Col
                        };
                        token.Type = type;

                        tokens.Add(token);
                    }
                    else if(c == '.')
                    {
                        token.val = c.ToString();
                        token.location = new Location
                        {
                            Line = location.Line,
                            Col = location.Col
                        };
                        token.Type = TokenType.Dot;

                        tokens.Add(token);
                    }
                    else if (c == ';') // EOF
                    {
                        token.val = c.ToString();
                        token.location = new Location
                        {
                            Line = location.Line,
                            Col = location.Col
                        };
                        token.Type = TokenType.SemmiColon;

                        tokens.Add(token);
                    }
                    else if(c == '(')
                    {
                        token.val = c.ToString();
                        token.location = new Location
                        {
                            Line = location.Line,
                            Col = location.Col
                        };
                        token.Type = TokenType.LeftParen;

                        tokens.Add(token);
                    }
                    else if(c == ')')
                    {
                        token.val = c.ToString();
                        token.location = new Location
                        {
                            Line = location.Line,
                            Col = location.Col
                        };
                        token.Type = TokenType.RightParen;

                        tokens.Add(token);
                    }
                }
                else if (c == '\n')
                {
                    location.Line++;
                    location.Col = 0;
                }

                i++;
                location.Col++;
            }

            foreach (var token in tokens) 
            { 
                Console.WriteLine($"({token.Type.ToString()}, {token.val}, ({token.location.Line}, {token.location.Col}))");
            }
        }
    }
}
