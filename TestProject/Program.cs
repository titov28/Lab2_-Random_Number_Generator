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
            
            CongruentMethod cong = new CongruentMethod();
            cong.SetArr(10, 1000);
            cong.Print();

            RandomNumberFile randF = new RandomNumberFile();
            randF.SetArr(10, 1000);
            randF.Print();

            XiSquare myXI = new XiSquare();

            myXI.Set(cong.randomNumberArray, 1000);
            myXI.Print();

            Console.ReadLine();
        }
    }
}
