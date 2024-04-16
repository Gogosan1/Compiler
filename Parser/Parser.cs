namespace Compiler;

public class Parser
{
    public Dictionary<LexemeType, IState> StateMap;
    public StringHelper StringHelper { get; set; }
    public List<ParserError> Errors { get; set; }

    public List<ParserError> Parse(string text = "")
    {
        Errors.Clear();
        StringHelper.Source = text;

        StateMap[LexemeType.CONST].Handle();
        return Errors;
    }
    public Parser(string text)
    {
        Errors = new List<ParserError>();
        StringHelper = new StringHelper(text);
        StateMap = new Dictionary<LexemeType, IState>();

        StateMap.Add(LexemeType.CONST, new ConstState(Errors, StringHelper, StateMap));
        StateMap.Add(LexemeType.DOUBLE, new DoubleState(Errors, StringHelper, StateMap));
        StateMap.Add(LexemeType.Identifier, new IdState(Errors, StringHelper, StateMap));
        StateMap.Add(LexemeType.AssignmentOperator, new AssignmentOperatorState(Errors, StringHelper, StateMap));
        StateMap.Add(LexemeType.Sign, new SignState(Errors, StringHelper, StateMap));
        StateMap.Add(LexemeType.INT, new IntegerState(Errors, StringHelper, StateMap));
        StateMap.Add(LexemeType.DECIMAL, new DecimalState(Errors, StringHelper, StateMap));
        StateMap.Add(LexemeType.Semicolon, new SemicolonState(Errors, StringHelper, StateMap));
    }
}
