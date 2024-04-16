namespace Compiler;

public class IdState : IState
{
    private List<ParserError> errors;
    private StringHelper stringHelper;
    private Dictionary<LexemeType, IState> StateMap;

    public IdState(List<ParserError> errors, StringHelper stringHelper, Dictionary<LexemeType, IState> StateMap)
    {
        this.errors = errors;
        this.stringHelper = stringHelper;
        this.StateMap = StateMap;
    }

    public bool Handle()
    {
        stringHelper.SkipSpaces();

        if (!stringHelper.CanGetCurrent)
        {
            errors.Add(new ParserError("Обнаружено незаконченное выражение", stringHelper.Index, stringHelper.Index, ErrorType.UnfinishedExpression));
            return false;
        }

        char currentSymbol = stringHelper.Current;
        bool IsNotFirstSymbol = false;
        bool spaseBetweenLetters = false;

        ParserError error = new ParserError("Ожидался идентификатор", stringHelper.Index + 1, stringHelper.Index + 1);
        
        while (stringHelper.Current != '=')
        {
            if (!stringHelper.CanGetNext)
            {
                if (error.Value != string.Empty)
                    errors.Add(error);
                errors.Add(new ParserError("Обнаружено незаконченное выражение", stringHelper.Index, stringHelper.Index, ErrorType.UnfinishedExpression));
                return false;
            }

            currentSymbol = stringHelper.Current;
            char help = ' ';
            if (char.IsLetter(currentSymbol))
                help = 'l';
            if (char.IsDigit(currentSymbol) || currentSymbol == '_')
                help = 'd';
            
            if (stringHelper.Current == ' ')
                help = ' ';

            switch(help)
            {
                case 'l':
                    IsNotFirstSymbol = true;
                    if (spaseBetweenLetters && currentSymbol != '=')
                    {
                        error.Value += currentSymbol;
                        error.EndIndex = stringHelper.Index + 1;
                        // ошибка
                        currentSymbol = stringHelper.Next;
                    }
                    else
                    {
                        if (error.Value != string.Empty)
                            errors.Add(error);
                        error = new ParserError("Ожидался идентификатор", stringHelper.Index + 1, stringHelper.Index + 1);
                        currentSymbol = stringHelper.Next;
                    }
                    break;
                case 'd':
                    if (!IsNotFirstSymbol)
                    {
                        error.Value += currentSymbol;
                        error.EndIndex = stringHelper.Index + 1;
                        // ошибка

                    }
                    else
                    {
                        if (error.Value != string.Empty)
                            errors.Add(error);
                        error = new ParserError("Ожидался идентификатор", stringHelper.Index + 1, stringHelper.Index + 1);
                    }
                        currentSymbol = stringHelper.Next;
                    break;
                case ' ':
                    spaseBetweenLetters = true;
                    while (currentSymbol == ' ') // сломается при переносе строки
                    {
                        currentSymbol = stringHelper.Next;
                    }
                    break;
                default:
                    if (currentSymbol == '=')
                        break;
                    error.Value += currentSymbol;
                    error.EndIndex = stringHelper.Index + 1;
                    currentSymbol = stringHelper.Next;
                    break;

            }
 
            if (currentSymbol == '=')
            {
                if (error.Value != string.Empty)
                    errors.Add(error);
                error = new ParserError("Ожидался идентификатор", stringHelper.Index + 1, stringHelper.Index + 1);
                break;
            }
            //currentSymbol = stringHelper.Next;
        }

        if (!IsNotFirstSymbol)
        {
            errors.Add(error);
        }

        StateMap[LexemeType.AssignmentOperator].Handle();
        return true;
    }
}
