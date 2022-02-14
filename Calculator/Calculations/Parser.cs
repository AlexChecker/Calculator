using System;
using System.Collections.Generic;
using System.Windows.Documents;
using Calculator.Calculations.Tokens;
using Calculator.Calculations.Tokens.subtokens;

namespace Calculator.Calculations
{
    public class Parser
    {
        private Tokenizer tokomak = new Tokenizer();//Для тех кто в танке: Токомак - прототип ядерного реактора. Хз зачем я это написал...

        bool hasOperatorsLeft(List <Token> list)
        {
            foreach (Token t in list)
            {
                if (t is ActionToken) return true;
                if (t is FunctionToken) return true;
                if (t is Factorial) return true;
            }

            return false;
        }

        bool morePrior(Token t , List<Token> tokens)
        {
            foreach (var tk in tokens)
            {
                if (tk.GetType() == typeof(Plus) || tk.GetType() == typeof(Minus) || tk.GetType() == typeof(Multiply) ||
                    tk.GetType() == typeof(Divide) || tk.GetType() == typeof(Mod) || tk.GetType() == typeof(Pow))
                {
                    if (((ActionToken) tk).prior > ((ActionToken) t).prior) return false;
                }
                else if (tk.GetType() == typeof(FunctionToken) || tk.GetType() == typeof(Factorial)) return false;
            }

            return true;
        }

        public double parse(string input)
        {
            List<Token> tokens = tokomak.Tokenize(input);
            double a = 0;
            double b = 0;
            double result = 0;
            while (hasOperatorsLeft(tokens))
            {
                for (int i = 0; i < tokens.Count; i++)
                {
                    int next = i + 1;
                    int behind = i - 1;
                    try
                    {
                        if (tokens[behind].GetType() == typeof(BracketsToken))
                        {
                            a = parse(((BracketsToken) tokens[behind]).group);
                            if (tokens[next].GetType() == typeof(BracketsToken))
                            {
                                b = parse(((BracketsToken) tokens[next]).group);
                            }
                            else
                            {
                                b = ((NumberToken) tokens[next]).eval();
                            }
                        }
                        else if (tokens[next].GetType() == typeof(BracketsToken))
                        {
                            b = parse(((BracketsToken) tokens[next]).group);
                            if (tokens[behind].GetType() == typeof(BracketsToken))
                            {
                                a = parse(((BracketsToken) tokens[behind]).group);
                            }
                            else
                            {
                                a = ((NumberToken) tokens[behind]).eval();
                            }
                        }
                        else
                        {
                            a= ((NumberToken) tokens[behind]).eval();
                            b = ((NumberToken) tokens[next]).eval();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("ВНИМАНИЕ!\nЗдесь постоянно происходит какая-то малопонятная хуита, разрывающая пердаки сотням\nдолбоёбов каждый божий день, здесь мы любим противоречить сами себе,\nвводя в ступор даже бывалых интеллектуалов, поэтому убедительная просьба съебать от\nэкрана всех опездалов с мозгом ребенка, сферических матерей, кормящих лошадей,боевых пидарасов, ниндзя хомячков, дряблопёздых впечатлительных натур,высокоморальных и не ебаться высокодуховных хуйлопанов ибо здесь густо говорят на чистом русском языке в каждом втором, нет, первом видео и да: здесь круглосуточно работают модераторы, которые могут послать тебя на скамью запасных дегенератов или хуй,в лес, сад, жопу (нужное подчеркнуть) за \"сильно умный\" или дерзкий комментарий, а потом в бан потому, что пошёл нахуй, вот почему.Всех остальных - адекватных, с чувством юмора, способных смотреть весь пиздец,что сейчас будет происходить на экране, через гиперкубическую призму наркомании и нашей суровой реальности, милости просим! ");
                    }

                    if (tokens[i] is Factorial)
                    {
                        double temp = ((Factorial) tokens[i]).operate(tokens[behind].eval());
                        tokens.RemoveAt(i);
                        tokens.RemoveAt(behind);
                        tokens.Insert(i-1,new NumberToken(temp));
                        continue;
                    }

                    if (tokens[i] is FunctionToken)
                    {
                        double temp = ((FunctionToken) tokens[i]).eval();
                        tokens.RemoveAt(i);
                        tokens.Insert(i,new NumberToken(temp));
                        continue;
                    }

                    if (tokens[i] is Divide && morePrior(tokens[i], tokens))
                    {
                        double temp = ((Divide) tokens[i]).operate(a, b);
                        tokens.RemoveAt(i);
                        tokens.Insert(i,new NumberToken(temp));
                        tokens.RemoveAt(next);
                        tokens.RemoveAt(behind);
                        continue;
                    }
                    if (tokens[i] is Mod && morePrior(tokens[i], tokens))
                    {
                        double temp = ((Mod) tokens[i]).operate(a, b);
                        tokens.RemoveAt(i);
                        tokens.Insert(i,new NumberToken(temp));
                        tokens.RemoveAt(next);
                        tokens.RemoveAt(behind);
                        continue;
                    }
                    if (tokens[i] is Pow && morePrior(tokens[i], tokens))
                    {
                        double temp = ((Pow) tokens[i]).operate(a, b);
                        tokens.RemoveAt(i);
                        tokens.Insert(i,new NumberToken(temp));
                        tokens.RemoveAt(next);
                        tokens.RemoveAt(behind);
                        continue;
                    }
                    if (tokens[i] is Multiply && morePrior(tokens[i], tokens))
                    {
                        double temp = ((Multiply) tokens[i]).operate(a, b);
                        tokens.RemoveAt(i);
                        tokens.Insert(i,new NumberToken(temp));
                        tokens.RemoveAt(next);
                        tokens.RemoveAt(behind);
                        continue;
                    }
                    if (tokens[i] is Plus && morePrior(tokens[i], tokens))
                    {
                        double temp = ((Plus) tokens[i]).operate(a, b);
                        tokens.RemoveAt(i);
                        tokens.Insert(i,new NumberToken(temp));
                        tokens.RemoveAt(next);
                        tokens.RemoveAt(behind);
                        continue;
                    }
                    if (tokens[i] is Minus && morePrior(tokens[i], tokens))
                    {
                        if (i == 0)
                        {
                            double temp2 = -((NumberToken) tokens[next]).eval();
                            tokens.RemoveAt(next);
                            tokens.RemoveAt(i);
                            tokens.Insert(0,new NumberToken(temp2)); 
                            continue;
                        }

                        double temp = ((Minus) tokens[i]).operate(a, b);
                        tokens.RemoveAt(i);
                        tokens.Insert(i,new NumberToken(temp));
                        tokens.RemoveAt(next);
                        tokens.RemoveAt(behind);
                        continue;
                    }

                }
            }

            result = tokens[0].eval();
            return result;

        }
    }
}