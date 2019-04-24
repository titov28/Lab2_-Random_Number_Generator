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
        private int[,] randomNumberArray;

        public RandomNumberFile(int[,] randArr)
        {
            randomNumberArray = randArr;

            ReadFile();
            Init();
        }


        private void Init()
        {
            int mod = 10;
            Random rand = new Random();

            int indexI = 0;
            int indexJ = 0;

            for (int i = 0; i < randomNumberArray.GetUpperBound(1) + 1; i++)
            {
                for (int j = 0; j < randomNumberArray.GetUpperBound(0) + 1; j++)
                {
                    indexI = rand.Next(fileArray.GetUpperBound(0) + 1);
                    indexJ = rand.Next(fileArray.GetUpperBound(1) + 1);

                    if(fileArray[indexI, indexJ] < 1000 || fileArray[indexI, indexJ] % mod < mod / 10)
                    {
                        j--;
                        continue;
                    }

                    randomNumberArray[j, i] = fileArray[indexI, indexJ] % mod;
                }
                mod *= 10;
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

            for (int i = 0; i < randomNumberArray.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < randomNumberArray.GetUpperBound(1) + 1; j++)
                {
                    Console.Write("{0, 5}", randomNumberArray[i, j]);
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }
    }
}
