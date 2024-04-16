namespace Lab5;

public class PolishNotationCalculator
{
    public string infixExpr { get; private set; }
    public string postfixExpr { get; private set; }

    private Dictionary<char, int> operationPriority = new() {
        {'(', 0},
        {'+', 1},
        {'-', 1},
        {'*', 2},
        {'/', 2},
        {'^', 3},
        {'~', 4}
    };

    public PolishNotationCalculator(string expression)
    {
        infixExpr = expression;
        postfixExpr = ToPostfix(infixExpr + "\r");
    }

    private string GetStringNumber(string expr, ref int pos)
    {
        string strNumber = "";

        for (; pos < expr.Length; pos++)
        {
            char num = expr[pos];

            if (Char.IsDigit(num))
                strNumber += num;
            else
            {
                pos--;
                break;
            }
        }

        return strNumber;
    }

    private string ToPostfix(string infixExpr)
    {
        string postfixExpr = "";
        Stack<char> stack = new();

        for (int i = 0; i < infixExpr.Length; i++)
        {
            char c = infixExpr[i];

            if (Char.IsDigit(c))
            {
                postfixExpr += GetStringNumber(infixExpr, ref i) + " ";
            }
            else if (c == '(')
            {
                stack.Push(c);
            }
            else if (c == ')')
            {
                while (stack.Count > 0 && stack.Peek() != '(')
                    postfixExpr += stack.Pop() + " ";
                stack.Pop();
            }
            else if (operationPriority.ContainsKey(c))
            {
                char op = c;
                if (op == '-' && (i == 0 || (i > 1 && operationPriority.ContainsKey(infixExpr[i - 1]))))
                    op = '~';

                while (stack.Count > 0 && (operationPriority[stack.Peek()] >= operationPriority[op]))
                    postfixExpr += stack.Pop() + " ";
                stack.Push(op);
            }
            else if (c != '\r' && c != '\n')
            {
                throw new ArgumentException($"Обнаружен недопустимый символ в выражении: \"{c}\"");
            }
        }
        foreach (char op in stack)
            postfixExpr += op + " ";

        return postfixExpr;
    }

    private double Execute(char op, double first, double second)
    {
        switch (op)
        {
            case '+':
                return first + second;
            case '-':
                return first - second;
            case '*':
                return first * second;
            case '/':
                if (second == 0)
                {
                    throw new DivideByZeroException("Невозможно выполнить деление на ноль");
                }
                return first / second;
            case '^':
                return Math.Pow(first, second);
            default:
                throw new ArgumentException("Недопустимая операция: " + op);
        }
    }

    public double Calc()
    {
        Stack<double> locals = new();
        int counter = 0;

        for (int i = 0; i < postfixExpr.Length; i++)
        {
            char c = postfixExpr[i];

            if (Char.IsDigit(c))
            {
                string number = GetStringNumber(postfixExpr, ref i);
                locals.Push(Convert.ToDouble(number));
            }
            else if (operationPriority.ContainsKey(c))
            {
                counter += 1;
                if (c == '~')
                {
                    double last = locals.Count > 0 ? locals.Pop() : 0;

                    locals.Push(Execute('-', 0, last));
                    continue;
                }

                double second = locals.Count > 0 ? locals.Pop() : 0,
                first = locals.Count > 0 ? locals.Pop() : 0;

                locals.Push(Execute(c, first, second));
            }
        }

        return locals.Pop();
    }
}
