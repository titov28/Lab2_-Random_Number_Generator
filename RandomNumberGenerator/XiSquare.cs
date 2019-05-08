using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumberGenerator
{
    public class XiSquare
    {
        public double Xi {get;set;} // Xi квадрат
        public double p; // вероятность
        private int k ; // количество интервалов
        private int[] randomNumberArray; // выборка случайных величин
        private double[] mj; // число попапданий случайной величины в интервал
        private double[] intervals;

        public void Set(int[] arr)
        {
            randomNumberArray = arr;
            Xi = 0.0;

            InitInterval();
            InitMJ();
            Init();
        }

        private void InitMJ()
        {
            mj = new double[k];

            for(int i = 0; i < randomNumberArray.Length; i++)
            {
                for(int j = 0; j < k; j++)
                {
                    if (randomNumberArray[i] <= intervals[j + 1]) {
                        mj[j] += 1.0;
                        break;
                    }
                }
            }

        }

        private void InitInterval()
        {
            int min = int.MaxValue;
            int max = -1;
            k = NumberOfUniqueNumbers();

            if (k > 3)
            {
                k = 10;
            }

            InitMinMax(ref min, ref max);

            double step = Math.Round((double)(max - min) / k, 2);

            
            intervals = new double[k + 1];

            double temp = min;

            for(int i = 0; i < k + 1; i++)
            {
                intervals[i] = temp;
                temp = Math.Round(temp + step, 2);
            }

        }

        private int NumberOfUniqueNumbers()
        {
            int count = 0;
            int[] locArr = randomNumberArray.Clone() as int[];

            int size = randomNumberArray.Length;
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    if(i != j)
                    {
                        if(locArr[i] == locArr[j])
                        {
                            locArr[j] = -1;
                        }
                    }
                }

            }

            for (int i = 0; i < size; i++)
            {
                if (locArr[i] != -1)
                {
                    count++;
                }
            }

            return count;
        }

        private void InitMinMax(ref int min,ref int max)
        {
            for(int i = 0; i < randomNumberArray.Length; i++)
            {
                if(randomNumberArray[i] > max)
                {
                    max = randomNumberArray[i];
                }

                if (randomNumberArray[i] < min)
                {
                    min = randomNumberArray[i];
                }

            }

        }

        private void Init()
        {
            double locP = 1.0 / k;
            int N = randomNumberArray.Length;


            for (int i = 0; i < k; i++)
            {
                if(mj[i] != 0)
                    Xi += Math.Pow(mj[i] - N * locP, 2) / (N * locP);
            }


            if (Xi <= 2.09)
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
            else if (Xi > 8.34 && Xi <= 11.39)
            {
                p = 0.75;
            }
            else if (Xi > 11.39 && Xi <= 16.92)
            {
                p = 0.95;
            }
            else 
            {
                p = 0.99;
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
