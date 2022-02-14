using System;

namespace Calculator.Calculations.Tokens.subtokens
{
    public class FunctionToken : Token
    {
        public string name;
        public string args;
        private Parser parser = new Parser();

        public FunctionToken(string name,string args)
        {
            this.name = name;
            this.args = args;
        }

        public override double eval()
        {
            double result = 0;
            double d = parser.parse(args);
            switch (name)
            {
                case "sin":
                    result =Math.Sin(d);
                    break;
                case "cos":
                    result =Math.Cos(d);
                    break;
                case "mod":
                case "abs":
                    result =Math.Abs(d);
                    break;
                case "sqrt":
                    result = Math.Sqrt(d);
                    break;
                case "arcsin":
                    result =Math.Asin(d);
                    break;
                case "arccos":
                    result =Math.Acos(d);
                    break;
                case "ln":
                    result = Math.Log(d);
                    break;
                case "divx":
                    result = 1.0 / d;
                    break;
                case "cbrt":
                    result = Math.Pow(d, 1.0 / 3.0);
                    break;
                case "pten":
                    result = Math.Pow(10.0,d);
                    break;
                case "ptwo":
                    result = Math.Pow(2.0, d);
                    break;
            }

            return result;
        }
    }
}