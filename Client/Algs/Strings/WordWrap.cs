using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Client.Algs
{
    public class WordWrapProblem
    {
        private int[] a;
        private int[,] c;
        private int line = 20;
        private int Inf = 999999;
        private List<string> words;

        public WordWrapProblem(List<string> ws)
        {
            this.a = ws.Select(w => w.Length).ToArray();
            c = new int[a.Length,a.Length];

            this.words = ws;
        }

        public void Wrap()
        {
            BuilLinesCost();

            var indices = WrapWords();

            Print(indices);
        }

        private int[] WrapWords()
        {
            var al = a.Length;
            var cost = new int[al];
            var indices = new int[al];

            for (int i = al - 1; i >= 0; i--)
            {
                cost[i] = c[i, al - 1];
                indices[i] = al;

                for (var j = al - 1; j > i; j--)
                {
                    if (c[i, j - 1] == Inf)
                        continue;

                    if (cost[j] + c[i, j - 1] <= cost[i])
                    {
                        cost[i] = cost[j] + c[i, j - 1];
                        indices[i] = j;
                    }
                }
            }

            return indices;
        }

        public void Print(int[] result)
        {
            var i = 0;
            int j;

            do
            {
                j = result[i];
                var builder = new StringBuilder();

                for (int k = i; k < j; k++)
                {
                    builder.Append(words[k] + " ");
                }

                Console.WriteLine(builder.ToString());
                i = j;
            } while (j < words.Count);
        }

        private void BuilLinesCost()
        {
            var al = a.Length;

            for (var i = 0; i < al; i++)
            {
                var lenght = 0;
                for (var j = i; j < al; j++)
                {
                    lenght += a[j];
                    if (lenght <= line)
                    {
                        c[i, j] = (int) Math.Pow(line - lenght, 2);
                        lenght++;
                    }
                    else
                    {
                        c[i, j] = Inf;
                    }

                }
            }
        }
    }
}