using System.Data;


namespace Compiler;

public class ReqParser
{
    private List<Lexeme> tokens;
    private Lexeme CurrToken;
    private int CurrIndex;
    private int MaxIndex;

    public string Input {  get; set; } 
    public List<ParserError> Errors { get; set; }

    public ReqParser()
    {
        Errors = new List<ParserError>();
    }

    public List<ParserError> Parse(List<Lexeme> tokensList)
    {
        Errors.Clear();
        if (tokensList.Count <= 0)
            return Errors;
        tokens = tokensList;
        GetAndRemoveInvalidLexemes(tokensList);
        CurrIndex = 0;
        MaxIndex = tokens.Count - 1;
        CurrToken = tokens[CurrIndex];

        try
        {
            CONSTANT(false);
        }
        catch (SyntaxErrorException)
        {
            if (CurrToken.Type != LexemeType.Semicolon)
                Errors.Add(new ParserError($"Выражение незакончено", CurrToken.StartIndex, tokens[MaxIndex].EndIndex, ErrorType.UnfinishedExpression));
        }

        return Errors;
    }

    public void GetAndRemoveInvalidLexemes(List<Lexeme> lexemes)
    {
        bool flag = false;
        LexicalAnalyzer analyzer = new LexicalAnalyzer();
        string modifidedInput = "";
        for (int i = lexemes.Count - 1; i >= 0; i--)
        {
            var lexeme = lexemes[i];
            if (lexeme.Type == LexemeType.Whitespace || lexeme.Type == LexemeType.NewLine || lexeme.Type == LexemeType.InvalidCharacter)
            {
                Errors.Add(new ParserError($"Недопустимый символ \"{lexeme.Value}\"", lexeme.StartIndex, lexeme.EndIndex, ErrorType.UnfinishedExpression));
                lexemes.RemoveAt(i);
                flag = true;
                modifidedInput = Input.Remove(lexeme.StartIndex - 1, 1);
                Input = modifidedInput;
            }
        }
        if (flag)
            tokens = analyzer.Analyze(modifidedInput);
    }

    private void ChangeCurrentToken()
    {
        if (CanGetNext())
        {
            CurrIndex++;
            CurrToken = tokens[CurrIndex];
        }
        else
        {
            throw new SyntaxErrorException();
        }
    }

    private LexemeType GetNextType()
    {
        return CanGetNext() ? tokens[CurrIndex + 1].Type : LexemeType.Error;
    }

    private bool CanGetNext() => CurrIndex < MaxIndex;

    private void CONSTANT(bool get, bool neutralize = false)
    {
        if (get && CurrToken.Type != LexemeType.CONST) ChangeCurrentToken();

        if (CurrToken.Type == LexemeType.CONST)
        {
            DOUBLE(true);
        }
        else
        {
            if (CurrToken.Type == LexemeType.DOUBLE && GetNextType() == LexemeType.CONST)
            {
                Errors.Add(new ParserError($"Пропущено ключевое слово const", CurrToken.StartIndex, tokens[MaxIndex].EndIndex, ErrorType.UnfinishedExpression));
                DOUBLE(false);
            }
            else
            {
                Errors.Add(new ParserError($"Ожидалось ключевое слово const, а встречено \"{CurrToken.Value}\"", CurrToken.StartIndex, tokens[MaxIndex].EndIndex, ErrorType.UnfinishedExpression));

                if (GetNextType() == LexemeType.CONST)
                    CONSTANT(true);
                else
                    DOUBLE(true);
            }
        }
    }

    private void DOUBLE(bool get, bool neutralize = false)
    {
        if (get && CurrToken.Type != LexemeType.DOUBLE) ChangeCurrentToken();

        if (CurrToken.Type == LexemeType.DOUBLE)
        {
            NAME(true);
        }
        else 
        {
            if (CurrToken.Type == LexemeType.Identifier && GetNextType() == LexemeType.AssignmentOperator)
            {
                Errors.Add(new ParserError($"Пропущено ключевое слово double", CurrToken.StartIndex, tokens[MaxIndex].EndIndex, ErrorType.UnfinishedExpression));
                NAME(false);
            }
            else
            {
                Errors.Add(new ParserError($"Ожидалось ключевое слово double, а встречено \"{CurrToken.Value}\"", CurrToken.StartIndex, tokens[MaxIndex].EndIndex, ErrorType.UnfinishedExpression));

                if (GetNextType() == LexemeType.DOUBLE)
                    DOUBLE(true);
                else
                    NAME(true);
            }
        }
    }

    private void NAME(bool get, bool neutralize = false)
    {
        if (get) ChangeCurrentToken();

        if (CurrToken.Type == LexemeType.Identifier)
        {
            SIGN(true);
        }
        else
        {
            if (CurrToken.Type == LexemeType.AssignmentOperator)
            {
                Errors.Add(new ParserError($"Пропущен идентификатор", CurrToken.StartIndex, tokens[MaxIndex].EndIndex, ErrorType.UnfinishedExpression));
                SIGN(false);
            }
            else
            {
                Errors.Add(new ParserError($"Ожидался идентификатор, а встречено \"{CurrToken.Value}\"", CurrToken.StartIndex, tokens[MaxIndex].EndIndex, ErrorType.UnfinishedExpression));

                if (GetNextType() == LexemeType.Identifier)
                    NAME(true);
                else
                    SIGN(true);
            }
        }
    }

    private void SIGN(bool get, bool neutralize = false)
    {
        if (get && CurrToken.Type != LexemeType.AssignmentOperator) ChangeCurrentToken();

        if (CurrToken.Type == LexemeType.AssignmentOperator)
        {
            INT(true);
        }
        else
        {
            if (CurrToken.Type == LexemeType.Sign || CurrToken.Type == LexemeType.UnsignedInteger)
            {
                Errors.Add(new ParserError($"Пропущен оператор присваивания", CurrToken.StartIndex, tokens[MaxIndex].EndIndex, ErrorType.UnfinishedExpression));
                INT(false);
            }
            else
            {
                Errors.Add(new ParserError($"Ожидался оператор присваивания, а встречено \"{CurrToken.Value}\"", CurrToken.StartIndex, tokens[MaxIndex].EndIndex, ErrorType.UnfinishedExpression));

                if (GetNextType() == LexemeType.AssignmentOperator)
                    SIGN(true);
                else
                    INT(true);
            }
        }
    }

    private void INT(bool get, bool neutralize = false)
    {
        if (get) ChangeCurrentToken();

        if (CurrToken.Type == LexemeType.Sign || CurrToken.Type == LexemeType.UnsignedInteger || neutralize)
        {
            UNSIGNEDINT(CurrToken.Type == LexemeType.Sign);
        }
        else
        {
            if (CurrToken.Type == LexemeType.Semicolon)
            {
                Errors.Add(new ParserError($"Пропущен знак или число", CurrToken.StartIndex, tokens[MaxIndex].EndIndex, ErrorType.UnfinishedExpression));
                UNSIGNEDINT(false);
            }
            else
            {
                Errors.Add(new ParserError($"Ожидался знак или число, а встречено \"{CurrToken.Value}\"", CurrToken.StartIndex, tokens[MaxIndex].EndIndex, ErrorType.UnfinishedExpression));

                if (GetNextType() == LexemeType.Sign || GetNextType() == LexemeType.UnsignedInteger)
                    INT(true);
                else
                    UNSIGNEDINT(true, true);
            }
        }
    }

   
    private void UNSIGNEDINT(bool get, bool neutralize = false, uint counter_of_points = 0)
    {
        if (get) ChangeCurrentToken();

        if (CurrToken.Type == LexemeType.UnsignedInteger)
        {
            POINT(true);
        }
        else
        {
            if (CurrToken.Type == LexemeType.Semicolon)
            {
                if (!neutralize)
                    Errors.Add(new ParserError($"Пропущено число", CurrToken.StartIndex, tokens[MaxIndex].EndIndex, ErrorType.UnfinishedExpression));
                END(false);
            }
            else
            {
                Errors.Add(new ParserError($"Ожидалось число, а встречено \"{CurrToken.Value}\"", CurrToken.StartIndex, tokens[MaxIndex].EndIndex, ErrorType.UnfinishedExpression));

                if (GetNextType() == LexemeType.UnsignedInteger)
                    UNSIGNEDINT(true);
                else
                  POINT(true);
            }
        }
    }

    private void POINT(bool get, bool neutralize = false)
    {
        if (get && CurrToken.Type != LexemeType.Decimal) ChangeCurrentToken();

        if (CurrToken.Type == LexemeType.Decimal)
        {
            DECIMAL(true);
        }
        else
        {
            if (CurrToken.Type == LexemeType.Semicolon)
            {
                END(false);
            }
            else
            {
                Errors.Add(new ParserError($"Ожидалась точка, а встречено \"{CurrToken.Value}\"", CurrToken.StartIndex, tokens[MaxIndex].EndIndex, ErrorType.UnfinishedExpression));
                END(true);
            }

        }
    }

    private void DECIMAL(bool get, bool neutralize = false)
    {
        if (get && CurrToken.Type != LexemeType.UnsignedInteger) ChangeCurrentToken();

        if (CurrToken.Type == LexemeType.UnsignedInteger)
        {
            END(true);
        }
        else
        {
            if (CurrToken.Type == LexemeType.Semicolon)
            {
                if (!neutralize)
                    Errors.Add(new ParserError($"Пропущена дробная часть числа", CurrToken.StartIndex, tokens[MaxIndex].EndIndex, ErrorType.UnfinishedExpression));
                END(false);
            }
            else
            {
                Errors.Add(new ParserError($"Ожидалась дробная часть числа, а встречено \"{CurrToken.Value}\"", CurrToken.StartIndex, tokens[MaxIndex].EndIndex, ErrorType.UnfinishedExpression));

                if (GetNextType() == LexemeType.UnsignedInteger)
                    UNSIGNEDINT(true);
                else
                    END(true);
            
            }
        }
    }


    private void END(bool get, bool neutralize = false)
    {
        if (get) ChangeCurrentToken();

        if (CurrToken.Type == LexemeType.Semicolon)
        {
            CONSTANT(true);
        }
        else
        {
            if (CurrToken.Type == LexemeType.CONST || GetNextType() == LexemeType.Error)
            {
                Errors.Add(new ParserError($"Пропущен оператор конца выражения", CurrToken.StartIndex, tokens[MaxIndex].EndIndex, ErrorType.UnfinishedExpression));
                if (GetNextType() != LexemeType.Error)
                    CONSTANT(false);
            }
            else
            {
                Errors.Add(new ParserError($"Ожидался оператор конца выражения, а встречено \"{CurrToken.Value}\"", CurrToken.StartIndex, tokens[MaxIndex].EndIndex, ErrorType.UnfinishedExpression));

                if (GetNextType() == LexemeType.Semicolon)
                    END(true);
                else
                    CONSTANT(true);
            }
        }
    }
}