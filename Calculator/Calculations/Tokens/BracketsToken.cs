namespace Calculator.Calculations.Tokens
{
    public class BracketsToken : Token
    {
        public string group;

        public BracketsToken(string group)
        {
            this.group = group;
        }
    }
}