using System.Windows.Media.Effects;

namespace Calculator.Calculations.Tokens.subtokens
{
    public class Factorial : ActionToken
    {
        public Factorial(char oper):base(oper)
        {
        }

        double fac(double n)
        {
            double result = 1;
            for (int i = 0; i < n; i++) result *= i;
            return result;
            
        }

        public double operate(double a)
        {
            return fac(a);
        }
    }
}