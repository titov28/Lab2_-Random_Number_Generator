using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomNumberGenerator;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] randArr = new int[10,3];
            int[,] randArrF = new int[10, 3];

            CongruentMethod cong = new CongruentMethod(randArr);
            cong.Print();

            RandomNumberFile randF = new RandomNumberFile(randArrF);
            randF.Print();

            Console.ReadLine();
        }
    }
}
