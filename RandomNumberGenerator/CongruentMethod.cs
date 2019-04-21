using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumberGenerator
{
    public class CongruentMethod
    {
        private static int Y = DateTime.Now.Millisecond;
        private int a = 165;
        private int m = 165498465;
        private int mu = 3463;
        private int[,] randomNumberArray;


        public CongruentMethod(int[,] randArray)
        {
            randomNumberArray = randArray;

            Init();
        }


        private void Init()
        {
            int mod = 10;
            int preY = 0;
            preY = (a * Y + mu) % m;

            for (int i = 0; i < randomNumberArray.GetUpperBound(1) + 1; i++)
            {
                for(int j = 0; j < randomNumberArray.GetUpperBound(0) + 1; j++)
                {
                    while(Math.Abs(preY % mod) < (mod/10))
                    {
                        preY = a * preY % m;
                    }

                    randomNumberArray[j, i] = Math.Abs(preY % mod);
                    preY = a * preY % m;
                }
                mod *= 10;
            }
        }


        public void Print()
        {
            Console.Write("Congruent Method\n\n");

            for (int i = 0; i < randomNumberArray.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < randomNumberArray.GetUpperBound(1) + 1; j++)
                {
                    Console.Write("{0, 5}",randomNumberArray[i, j]);
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }
    }
}
