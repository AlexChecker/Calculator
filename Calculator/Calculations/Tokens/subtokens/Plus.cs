namespace Calculator.Calculations.Tokens.subtokens
{
    public class Plus : ActionToken
    {
        public Plus(char oper) : base(oper)
        {
        }

        public override double operate(double a, double b)
        {
            return a + b;
        }
    }
}