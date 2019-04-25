using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RandomNumberGenerator
{
    public class RandomNumberFile
    {
        private string pathFile = @"Random.txt";
        private int[,] fileArray;
        public int[] randomNumberArray;
        private int mod;

        public RandomNumberFile()
        {
            randomNumberArray = null;

            ReadFile();
        }

        public void SetArr(int size, int mod)
        {
            randomNumberArray = new int[size];
            this.mod = mod;
            Init();
        }

        private void Init()
        {
            Random rand = new Random();

            int indexI = 0;
            int indexJ = 0;


            for (int j = 0; j < randomNumberArray.Length; j++)
            {
                indexI = rand.Next(fileArray.GetUpperBound(0) + 1);
                indexJ = rand.Next(fileArray.GetUpperBound(1) + 1);

                if (fileArray[indexI, indexJ] < 1000 || fileArray[indexI, indexJ] % mod < mod / 10)
                {
                    j--;
                    continue;
                }

                randomNumberArray[j] = fileArray[indexI, indexJ] % mod;
            }

        }


        private void ReadFile()
        {
            List<string> strList = new List<string>();
            using (StreamReader sr = new StreamReader(pathFile, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    strList.Add(line);
                }
            }

            int row = strList.Count;
            int column = strList.ElementAt(0).Split(' ').Length;

            fileArray = new int[row, column];


            string[] lineArr;

            for(int i = 0; i < row; i++)
            {
                lineArr = strList.ElementAt(i).Split(' ');
                for(int j = 0; j < column; j++)
                {
                    fileArray[i, j] = Convert.ToInt32(lineArr[j]);
                }
            }

        }



        public void Print()
        {
            Console.Write("Random Number File\n\n");

            for (int j = 0; j < randomNumberArray.Length; j++)
            {
                Console.WriteLine("{0, 5}", randomNumberArray[j]);
            }
            Console.Write("\n");
            
        }
    }
}
