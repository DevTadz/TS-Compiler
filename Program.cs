using TS_Compiler.Lexer;

MainLexer mainLexer = new MainLexer();

Main(mainLexer);

static void Main(MainLexer mainLexer)
{
    try
    {
        mainLexer.Lex();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.ToString());    
    }
}