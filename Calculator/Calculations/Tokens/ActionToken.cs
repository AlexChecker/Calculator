namespace Calculator.Calculations.Tokens
{
    public class ActionToken : Token
    {
        public char oper;
        public int prior;

        public ActionToken(char oper)
        {
            this.oper = oper;
            switch (oper)
            {
                case '^':
                    prior = 0;
                    break;
                case '/':
                case '*':
                case '%':
                    prior = 1;
                    break;
                default:
                    prior = 2;
                    break;
            }
        }

        public virtual double operate(double a, double b)
        {
            return 0;
        }
    }
}