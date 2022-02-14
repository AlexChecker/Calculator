using System;

namespace Calculator.Calculations.Tokens.subtokens
{
    public class Pow : ActionToken
    {
        public Pow(char oper) : base(oper)
        {
            
        }

        public override double operate(double a, double b)
        {
            return Math.Pow(a, b);
        }
    }
}