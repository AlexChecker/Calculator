namespace Calculator.Calculations.Tokens.subtokens
{
    public class Divide : ActionToken
    {
        public Divide(char oper): base(oper)
        {
            
        }

        public override double operate(double a, double b)
        {
            return a / b;
        }
    }
}