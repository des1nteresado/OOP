using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        static List<int> Sort = new List<int>();
        delegate void GetSort(int first, int last);
        GetSort get = new GetSort(SortBy);
        static string stroka = "";
        public static void SortBy(int first, int last)
        {
            Sort.Sort();
            if (first == 0)
            {
                for (int i = first; i < last; i++)
                {
                    stroka += "Макс. скорость: " + Sort[i] + Environment.NewLine;
                }
            }
            else
            {
                for (int i = first; i >= last; i--)
                {
                    stroka += "Макс. скорость: " + Sort[i] + Environment.NewLine;
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Sort.Sort();
            //textBox2.Clear();
            //for(int i = 0; i < Sort.Count; i++)
            //{
            //    textBox2.Text += "Макс. скорость: " + Sort[i] + Environment.NewLine;
            //}
            textBox2.Clear();
            get.Invoke(0, Sort.Count);
            textBox2.Text = stroka;
            stroka = "";
        }

        public void button1_Click(object sender, EventArgs e)
        {
            int c = Convert.ToInt32(textBox1.Text);
            if(c > 0)
            {
                textBox2.Clear();
                List<int> MaxSpeed = new List<int>(c);
                textBox1.TextAlign = HorizontalAlignment.Center;
                Random rnd = new Random();
                for (int i = 0; i < c; i++)
                {
                    MaxSpeed.Add(rnd.Next(100, 350));
                    textBox2.Text += "Макс. скорость: " + MaxSpeed[i].ToString() + Environment.NewLine;
                }
                Sort = MaxSpeed;
            }
            else
            {
                textBox1.Text = "Неверное значение";
            }
        }
        private void textBox1_Click(object sender, System.EventArgs e)
        {
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Sort.Sort();
            //textBox2.Clear();
            //for (int i = Sort.Count - 1; i >= 0; i--)
            //{
            //    textBox2.Text += "Макс. скорость: " + Sort[i] + Environment.NewLine;
            //}
            textBox2.Clear();
            get.Invoke(Sort.Count - 1, 0);
            textBox2.Text = stroka;
            stroka = "";
        }
    }
}
