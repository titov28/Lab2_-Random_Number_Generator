using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumberGenerator
{
    public class CongruentMethod
    {
        private int Y ;
        private int a = 165;
        private int m = 165498465;
        private int mu = 3463;
        public int[] randomNumberArray;
        int mod;

        public CongruentMethod()
        {
            randomNumberArray = null;
        }

        public void SetArr(int size, int mod)
        {
            Y = DateTime.Now.Millisecond;
            randomNumberArray = new int[size];
            this.mod = mod;
            Init();
        }
        private void Init()
        {

            int preY = 0;
            preY = (a * Y + mu) % m;

            for (int j = 0; j < randomNumberArray.Length; j++)
            {
                while (Math.Abs(preY % mod) < (mod / 10))
                {
                    preY = a * preY % m;
                }

                randomNumberArray[j] = Math.Abs(preY % mod);
                preY = a * preY % m;

            }
        }

            public void Print()
        {
            Console.Write("Congruent Method\n\n");


            for (int j = 0; j < randomNumberArray.Length; j++)
            {
                Console.WriteLine("{0, 5}", randomNumberArray[j]);
            }
            Console.Write("\n");

        }
    }
}
