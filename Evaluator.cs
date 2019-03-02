using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ConsoleApp4
{
    public class Evaluator
    {
        protected static Expression EvaluateCore(List<object> tokens)
        {
            int watchdog = 30;
            while (tokens.Count > 1 && watchdog-- > 0)
                Simplify(tokens);

            return (Expression)tokens[0];
        }
        protected static ExpressionType GetExpressionType(string exp)
        {
            switch (exp)
            {
                case "+": return ExpressionType.Add;
                case "-": return ExpressionType.Subtract;
                case "/": return ExpressionType.Divide;
                case "*": return ExpressionType.Multiply;
            }
            throw new Exception();
        }
        protected static void Simplify(List<object> tokens)
        {
            int startIndex = -1;
            for (int i = 0; i < tokens.Count - 2; i++)
                if (tokens[i] is Expression && tokens[i + 1] is Expression && tokens[i + 2] is string)
                {
                    startIndex = i;
                    break;
                }
            if (startIndex >= 0)
            {
                tokens[startIndex] = System.Linq.Expressions.Expression.MakeBinary(GetExpressionType((string)tokens[startIndex + 2]), (Expression)tokens[startIndex], (Expression)tokens[startIndex + 1]);
                tokens.Remove(tokens[startIndex + 1]);
                tokens.Remove(tokens[startIndex + 1]);
            }
        }

        public static string Evaluate(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
            }
            string[] words = str.Split(' ');
            List<object> tokens = new List<object>();
            foreach (var word in words)
            {
                double currentValue = 0;
                if (double.TryParse(word, out currentValue)) { tokens.Add(currentValue); }
                else { tokens.Add(word); }
            }
            for (int i = 0; i < tokens.Count; i++)
                if (tokens[i] is double)
                    tokens[i] = System.Linq.Expressions.Expression.Constant(tokens[i]);

            var result = EvaluateCore(tokens);
            double evalResult = (double)Expression.Lambda(result).Compile().DynamicInvoke();
            if (Math.Truncate(evalResult) == evalResult)
                return (evalResult).ToString("F1");
            else return (evalResult).ToString("F15");
        }
    }
}
