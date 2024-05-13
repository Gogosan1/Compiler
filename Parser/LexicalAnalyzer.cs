namespace Compiler;

public class LexicalAnalyzer
{
    List<Lexeme> Lexemes;

    public List<Lexeme> Analyze(string input)
    {
        int i;
        string value;

        Lexemes.Clear();

        for (i = 0; i < input.Length; i++)
        {
            value = string.Empty + input[i];

            if (char.IsLetter(input[i]))
            {
                int startIndex = i;

                while ((i + 1) < input.Length && (char.IsLetterOrDigit(input[i + 1]) || input[i + 1] == '_'))
                {
                    i++;
                    value += input[i];
                }

                switch (value)
                {
                    case "const":
                        Lexemes.Add(new Lexeme(LexemeType.CONST, value, startIndex + 1, i + 1));
                        break;
                    case "double":
                        Lexemes.Add(new Lexeme(LexemeType.DOUBLE, value, startIndex + 1, i + 1));
                        break;
                    default:
                        Lexemes.Add(new Lexeme(LexemeType.Identifier, value, startIndex + 1, i + 1));
                        break;
                }
            }
            else
            {
                if (char.IsDigit(input[i]))
                {
                    int startIndex = i;

                    while ((i + 1) < input.Length && char.IsDigit(input[i + 1]))
                    {
                        i++;
                        value += input[i];
                    }

                    Lexemes.Add(new Lexeme(LexemeType.UnsignedInteger, value, startIndex + 1, i + 1));
                }
                else
                {
                    switch (input[i])
                    {
                        case '\n':
                        case ' ':
                            //Lexemes.Add(new Lexeme(LexemeType.Whitespace, value, i + 1, i + 1));
                            break;
                        case (char)13:
                            if ((i + 1) < input.Length && input[i + 1] == (char)10)
                            {
                                i++;
                                value = "\\n";
                                //Lexemes.Add(new Lexeme(LexemeType.NewLine, value, i, i + 1));
                            }
                            else
                            {
                                Lexemes.Add(new Lexeme(LexemeType.InvalidCharacter, value, i + 1, i + 1));
                            }
                            break;
                        case '.':
                            Lexemes.Add(new Lexeme(LexemeType.Decimal, value, i + 1, i + 1));
                            break;
                        case '=':
                            Lexemes.Add(new Lexeme(LexemeType.AssignmentOperator, value, i + 1, i + 1));
                            break;
                        case '+':
                        case '-':
                            Lexemes.Add(new Lexeme(LexemeType.Sign, value, i + 1, i + 1));
                            break;
                        case ';':
                            Lexemes.Add(new Lexeme(LexemeType.Semicolon, value, i + 1, i + 1));
                            break;
                        default:
                            Lexemes.Add(new Lexeme(LexemeType.InvalidCharacter, value, i + 1, i + 1));
                            break;
                    }
                }
            }
        }

        return Lexemes;
    }

    public LexicalAnalyzer()
    {
        Lexemes = new List<Lexeme>();
    }
}


/*using System.Collections.Specialized;

namespace Compiler;

struct CorrectOrder
{
    public int isConstPrint = 0;
    public int isDoublePrint = 0;
    public int isIndetifierPrint = 0;
    public int isAssigmentOperatorPrint = 0;
    public int isNumberPrint = 0;

    public CorrectOrder()
    {
    }

   public int CounterOfPrintedLexemes()
    {
        int counter = isConstPrint + isDoublePrint + isIndetifierPrint + isAssigmentOperatorPrint + isNumberPrint;
        return counter;
    }
    public void MakeCounterZero ()
    {
        isConstPrint = 0;
        isDoublePrint = 0;
        isIndetifierPrint = 0;
        isAssigmentOperatorPrint = 0;
        isNumberPrint = 0;
    }
}

public class LexicalAnalyzer
{
    List<Lexeme> Lexemes;

    

    public List<Lexeme> Analyze(string input)
    {
        int i;
        string value;
        CorrectOrder correctOrder = new CorrectOrder();
        Lexemes.Clear();

        for (i = 0; i < input.Length; i++)
        {
            value = string.Empty + input[i];

            if (char.IsLetter(input[i]) && correctOrder.CounterOfPrintedLexemes() <= 3)
            {
                int startIndex = i;

                while ((i + 1) < input.Length && (char.IsLetterOrDigit(input[i + 1]) || input[i + 1] == '_'))
                {
                    i++;
                    value += input[i];
                }

                switch (value)
                {
                    case "const":
                        if (correctOrder.CounterOfPrintedLexemes() == 0)
                        {
                            Lexemes.Add(new Lexeme(LexemeType.CONST, value, startIndex + 1, i + 1));
                            correctOrder.isConstPrint = 1;
                        }else
                        {
                            Lexemes.Add(new Lexeme(LexemeType.InvalidCharacter, value, startIndex + 1, i + 1));
                        }
                        break;
                    case "double":
                        Lexemes.Add(new Lexeme(LexemeType.DOUBLE, value, startIndex + 1, i + 1));
                        correctOrder.isDoublePrint = 1;
                        break;
                    default:
                        Lexemes.Add(new Lexeme(LexemeType.Identifier, value, startIndex + 1, i + 1));
                        correctOrder.isIndetifierPrint = 1;
                        break;
                }
            }
            else
            {
                if (char.IsDigit(input[i]))
                {
                    int startIndex = i;

                    while ((i + 1) < input.Length && char.IsDigit(input[i + 1]))
                    {
                        i++;
                        value += input[i];
                    }
                    if (input[i + 1] == '.')
                    {
                        value += input[i + 1];
                        i++;

                        while ((i + 1) < input.Length && char.IsDigit(input[i + 1]))
                        {
                            i++;
                            value += input[i];
                        }
                        Lexemes.Add(new Lexeme(LexemeType.UnsignedDouble, value, startIndex + 1, i + 1));
                    }
                    else if (input[i + 1] == ';')
                    {
                        Lexemes.Add(new Lexeme(LexemeType.UnsignedInteger, value, startIndex + 1, i + 1));
                    }
                    
                }
                else
                {
                    switch (input[i])
                    {
                        case '\t':
                        case ' ':
                            Lexemes.Add(new Lexeme(LexemeType.Whitespace, value, i + 1, i + 1));
                            break;
                        case (char)10:
                            if ((i + 1) < input.Length && input[i + 1] == (char)10)
                            {
                                i++;
                                value = "\\n";
                                Lexemes.Add(new Lexeme(LexemeType.NewLine, value, i, i + 1));
                            }
                            else
                            {
                                Lexemes.Add(new Lexeme(LexemeType.InvalidCharacter, value, i + 1, i + 1));
                            }
                            break;
                        case '=':
                            Lexemes.Add(new Lexeme(LexemeType.AssignmentOperator, value, i + 1, i + 1));
                            break;
                        case '+':
                        case '-':
                            Lexemes.Add(new Lexeme(LexemeType.Sign, value, i + 1, i + 1));
                            break;
                        case ';':
                            Lexemes.Add(new Lexeme(LexemeType.Semicolon, value, i + 1, i + 1));
                            correctOrder.MakeCounterZero();
                            break;
                        default:
                            Lexemes.Add(new Lexeme(LexemeType.InvalidCharacter, value, i + 1, i + 1));
                            break;
                    }
                }
            }
        }

        return Lexemes;
    }

    public LexicalAnalyzer()
    {
        Lexemes = new List<Lexeme>();
    }
}*/