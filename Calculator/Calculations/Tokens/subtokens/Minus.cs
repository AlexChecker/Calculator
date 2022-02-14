namespace Calculator.Calculations.Tokens.subtokens
{
    public class Minus: ActionToken
    {
        public Minus(char oper): base(oper)
        {
            
        }

        public override double operate(double a,double b)
        {
            return a - b;
        }
    }
}