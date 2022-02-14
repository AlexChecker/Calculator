namespace Calculator.Calculations.Tokens.subtokens
{
    public class Mod : ActionToken
    {
        public Mod(char oper):base(oper)
        {
        }

        public override double operate(double a, double b)
        {
            return a % b;
        }
    }
}