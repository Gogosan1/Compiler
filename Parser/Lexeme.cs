using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler;

public enum LexemeType
{
    CONST = 1,
    DOUBLE = 2,
    Identifier = 3,
    Whitespace = 4,
    NewLine = 5,
    AssignmentOperator = 6,
    Sign = 7,
    UnsignedInteger = 8,
    Decimal = 9,
    Semicolon = 10,
    InvalidCharacter = 11,
    INT = 12,
    Error = 13,
    INTEGER = 14,
}

public class Lexeme
{
    private string[] lexemeNames;
    private string message;

    public int LexemeId { get => (int)Type; }
    //public string LexemeName { get => lexemeNames[LexemeId - 1]; }
    public LexemeType Type { get; set; }
    public string Value { get; set; }
    public int StartIndex { get; set; }
    public int EndIndex { get; set; }
    public string Position { get => $"с {StartIndex} по {EndIndex} символы"; }
    
    public string Message
    {
        get => $"{message} (Отброшенный фрагмент: \"{Value}\")";
        set => message = value;
    }

    public Lexeme(LexemeType type, string value, int startIndex, int endIndex)
    {
        Type = type;
        Value = value;
        StartIndex = startIndex;
        EndIndex = endIndex;

        lexemeNames =
        [
            "Ключевое слово",               // 1
            "Ключевое слово",               // 2
            "Идентификатор",                // 3
            "Пробел",                       // 4
            "Перенос на следующую строку",  // 5
            "Оператор присваивания",        // 6
            "Знак",                         // 7
            "Целое число",                  // 8 
            "Вещественное число",           // 9
            "Конец оператора",              // 10
            "Недопустимый символ"           // 11
        ];
    }
}