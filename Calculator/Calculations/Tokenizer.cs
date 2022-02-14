using System;
using System.Collections.Generic;
using Calculator.Calculations.Tokens;
using Calculator.Calculations.Tokens.subtokens;

namespace Calculator.Calculations
{
    public class Tokenizer
    {
        public List<Token> Tokenize(string raw)
        {
            List<Token> list = new List<Token>();

            string numbertmp = "";
            string temp = "";
            bool isArgs = false;
            string args = "";
            string inMath = "";
            bool isInMath = false;
            int stack = 0;
            foreach (char chr in raw)
            {
                if (chr == ',' && !numbertmp.Equals(""))
                {
                    numbertmp += ',';
                    continue;
                }

                if (isArgs)
                {
                    if (chr == '(')
                    {
                        stack++;
                    }

                    if (chr == ')')
                    {
                        if (stack > 0)
                        {
                            stack--;
                            args += chr;
                            continue;
                        }

                        isArgs = false;
                        list.Add(new FunctionToken(temp,args));
                        args = "";
                        temp = "";
                        continue;
                    }

                    args += chr;
                    continue;
                }

                if (isInMath)
                {
                    if (chr == '(')
                    {
                        stack++;
                    }

                    if (chr == ')')
                    {
                        if (stack <= 0)
                        {
                            isInMath = false;
                            list.Add(new BracketsToken(inMath));
                            inMath = "";
                        }

                        stack--;
                    }

                    inMath += chr;
                    continue;
                }

                if (chr == '(' && temp.Equals(""))
                {
                    isInMath = true;
                    continue;
                }

                 if (char.IsDigit(chr))
                {
                    numbertmp += chr;
                }
                else
                {
                    if (!numbertmp.Equals(""))
                    {
                        list.Add(new NumberToken(Double.Parse(numbertmp)));
                        numbertmp = "";
                    }

                    switch (chr)
                    {
                        case '+':
                            list.Add(new Plus(chr));
                            break;
                        case '-':
                            list.Add(new Minus(chr));
                            break;
                        case '*':
                            list.Add(new Multiply(chr));
                            break;
                        case '/':
                            list.Add(new Divide(chr));
                            break;
                        case '%':
                            list.Add(new Mod(chr));
                            break;
                        case '^':
                            list.Add(new Pow(chr));
                            break;
                        case '!':
                            list.Add(new Factorial(chr));
                            break;
                        default:
                            if(chr == ' ') continue;
                            if (chr == '(')
                            {
                                isArgs = true;
                                continue;
                            }

                            temp += chr;
                            continue;
                            break;
                    }

                }
            }

            if (!numbertmp.Equals(""))
            {
                list.Add(new NumberToken(Double.Parse(numbertmp)));
                numbertmp = "";
            }

            return list;
        }
    }
}