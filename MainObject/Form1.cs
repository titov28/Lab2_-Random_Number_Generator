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
        int rowCount = 10;

        public Form1()
        {
            InitializeComponent();

            dataGridView1.RowCount = rowCount;
            dataGridView2.RowCount = rowCount;
            dataGridView3.RowCount = rowCount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            string sb;


            CongruentMethod congruentMethod = new CongruentMethod();
            RandomNumberFile randomNumberFile = new RandomNumberFile();
            XiSquare xiSquare = new XiSquare();

            int rowCount = 10;
            int k = 10;

            
            for (int i = 0; i < 3; i++)
            {
                congruentMethod.SetArr(rowCount, k);

                randomNumberFile.SetArr(rowCount, k);

                for(int j = 0; j < rowCount; j++)
                {
                    dataGridView1[i, j].Value = congruentMethod.randomNumberArray[j];
                    dataGridView2[i, j].Value = randomNumberFile.randomNumberArray[j];
                }
                xiSquare.Set(congruentMethod.randomNumberArray, k);

                sb = "Xi = " + Math.Round(xiSquare.Xi, 3);
                sb += " P = " + xiSquare.p + "\t\t";
                textBox1.Text += sb;

                xiSquare.Set(randomNumberFile.randomNumberArray, k);

                sb = "Xi = " + Math.Round(xiSquare.Xi, 3);
                sb += " P = " + xiSquare.p + "\t\t";
                textBox2.Text += sb.ToString();

                k *= 10;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

            XiSquare xiSquare = new XiSquare();
            string sb;
            bool flag = false;
            textBox3.Text = string.Empty;

            
            int[] arr = new int[dataGridView3.RowCount];

            if (rowCount > 1)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    if (dataGridView3[0, i].Value != null)
                    {
                        arr[i] = Convert.ToInt32(dataGridView3[0, i].Value);
                        flag = true;
                    }
                }

                if (flag)
                {
                    xiSquare.Set(arr, 10);

                    sb = "Xi = " + Math.Round(xiSquare.Xi, 3);
                    sb += " P = " + xiSquare.p + "\t\t";
                    textBox3.Text += sb;
                }
            }
        }
    }
}
