using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumberGenerator
{
    public class XiSquare
    {
        public double Xi {get;set;}
        public double p;
        private int k; 
        private int[] randomNumberArray;

        public void Set(int[] arr, int k)
        {
            randomNumberArray = arr;
            Xi = 0.0;
            this.k = k;
            Init();
        }

        private void Init()
        {
            double locP = 1.0 / k;

            int sum = 0;

            for(int i = 0; i < randomNumberArray.Length; i++)
            {
                sum += randomNumberArray[i]; 
            }

            for(int i = 0; i < randomNumberArray.Length; i++)
            {
                Xi += Math.Pow(randomNumberArray[i] - sum * locP, 2) / (sum * locP);
            }

            if(Xi <= 2.09)
            {
                p = 0.01;
            }
            else if(Xi > 2.09 && Xi <= 2.70)
            {
                p = 0.025;
            }
            else if (Xi > 2.70 && Xi <= 3.33)
            {
                p = 0.05;
            }
            else if (Xi > 3.33 && Xi <= 4.17)
            {
                p = 0.1;
            }
            else if (Xi > 4.17 && Xi <= 5.38)
            {
                p = 0.2;
            }
            else if (Xi > 5.38 && Xi <= 6.39)
            {
                p = 0.3;
            }
            else if (Xi > 6.39 && Xi <= 7.36)
            {
                p = 0.4;
            }
            else if (Xi > 7.36 && Xi <= 8.34)
            {
                p = 0.5;
            }
            else if (Xi > 8.34 && Xi <= 9.41)
            {
                p = 0.6;
            }
            else 
            {
                p = 0.7;
            }
        }



        public void Print()
        {

            Console.Write("XiSquare\n\n");

            Console.Write("Xi = {0, 5:0.000} \n", Xi);
            Console.Write("p = {0, 5:0.000}\n", p);

        }
    }
}
