namespace Calculator.Calculations.Tokens.subtokens
{
    public class Multiply : ActionToken
    {
        public Multiply(char oper): base(oper)
        {
            
        }

        public override double operate(double a, double b)
        {
            return a * b;
        }
    }
}