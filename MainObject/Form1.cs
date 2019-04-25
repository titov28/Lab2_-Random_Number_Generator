using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RandomNumberGenerator;

namespace MainObject
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CongruentMethod congruentMethod = new CongruentMethod();
            RandomNumberFile randomNumberFile = new RandomNumberFile();
            XiSquare xiSquare = new XiSquare();

            int rowCount = 10;
            int k = 10;

            
            dataGridView1.RowCount = rowCount;
            dataGridView2.RowCount = rowCount;
            dataGridView3.RowCount = rowCount;
            for (int i = 0; i < 3; i++)
            {
                congruentMethod.SetArr(rowCount, k);

                randomNumberFile.SetArr(rowCount, k);

                for(int j = 0; j < rowCount; j++)
                {
                    dataGridView1[i, j].Value = congruentMethod.randomNumberArray[j];
                    dataGridView2[i, j].Value = randomNumberFile.randomNumberArray[j];
                }

                k *= 10;
            }


        }
    }
}
