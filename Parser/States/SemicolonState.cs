namespace Compiler;

public class SemicolonState : IState
{
    private List<ParserError> errors;
    private StringHelper stringHelper;
    private Dictionary<LexemeType, IState> StateMap;

    public SemicolonState(List<ParserError> errors, StringHelper stringHelper, Dictionary<LexemeType, IState> StateMap)
    {
        this.errors = errors;
        this.stringHelper = stringHelper;
        this.StateMap = StateMap;
    }

    public bool Handle()
    {
        if (stringHelper.CanGetNext)
        {
            _ = stringHelper.Next;
            StateMap[LexemeType.CONST].Handle();
        }
        else
        {
            return false;
        }
        return true;
    }
}
