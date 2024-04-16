using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Compiler;

public static class TextCleaner
{
    public static string RemoveIncorrectLexemes(string inputString, List<ParserError> _incorrectLexemes)
    {
        if (_incorrectLexemes.Last().ErrorType == ErrorType.UnfinishedExpression)
        {
            _incorrectLexemes.Remove(_incorrectLexemes.Last());
        }

        for (int i = _incorrectLexemes.Count-1; i > 0; i--)
        {
            int fragmentLength = _incorrectLexemes[i].EndIndex - _incorrectLexemes[i].StartIndex + 1;
            int fragmentStartIndex = _incorrectLexemes[i].StartIndex - 1;

            if (fragmentStartIndex > 0 && inputString[fragmentStartIndex - 1] == ' ' &&
                (fragmentStartIndex + fragmentLength) < (inputString.Length - 1) &&
                inputString[fragmentStartIndex + fragmentLength] == ' ')
                fragmentLength++;

            inputString = inputString.Remove(fragmentStartIndex, fragmentLength);
        }

        inputString = inputString.Replace("  ", " ");

        return inputString;
    }
}
