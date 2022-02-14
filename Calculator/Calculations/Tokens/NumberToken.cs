namespace Calculator.Calculations.Tokens
{
    public class NumberToken : Token
    {
        double value;

        public NumberToken(double val)
        {
            value = val;
        }

        public override double eval()
        {
            return value;
        }
    }
}