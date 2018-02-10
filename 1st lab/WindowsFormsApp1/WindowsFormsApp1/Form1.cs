using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int perem1;
            //Int32.TryParse(textBox1.Text, out perem1);
            //int perem2;
            //Int32.TryParse(textBox2.Text, out perem2);
            //int pr = perem1 | perem2;
            //string s = "";
            //s += pr;
            //textBox3.Text = s;
            if(radioButton1.Checked)
            {
                int pr1 = Convert.ToInt32(textBox1.Text);
                int pr2 = Convert.ToInt32(textBox2.Text);
                int or = pr1 & pr2;
                textBox3.Text = Convert.ToString(or, 2);
            }
            if (radioButton2.Checked)
            {
                int pr1 = Convert.ToInt32(textBox1.Text);
                int pr2 = Convert.ToInt32(textBox2.Text);
                int or = pr1 & pr2;
                textBox3.Text = Convert.ToString(or, 8);
            }
            if (radioButton3.Checked)
            {
                int pr1 = Convert.ToInt32(textBox1.Text);
                int pr2 = Convert.ToInt32(textBox2.Text);
                int or = pr1 & pr2;
                textBox3.Text = Convert.ToString(or, 10);
            }
            if (radioButton4.Checked)
            {
                int pr1 = Convert.ToInt32(textBox1.Text);
                int pr2 = Convert.ToInt32(textBox2.Text);
                int or = pr1 & pr2;
                textBox3.Text = Convert.ToString(or, 16);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(textBox3.Text);
            textBox3.Text = Convert.ToString(i, 8);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(textBox3.Text);
            textBox3.Text = Convert.ToString(i, 10);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(textBox3.Text);
            textBox3.Text = Convert.ToString(i, 2);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(textBox3.Text);
            textBox3.Text = Convert.ToString(i, 16);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                int pr1 = Convert.ToInt32(textBox1.Text);
                int pr2 = Convert.ToInt32(textBox2.Text);
                int or = pr1 | pr2;
                textBox3.Text = Convert.ToString(or, 2);
            }
            if (radioButton2.Checked)
            {
                int pr1 = Convert.ToInt32(textBox1.Text);
                int pr2 = Convert.ToInt32(textBox2.Text);
                int or = pr1 | pr2;
                textBox3.Text = Convert.ToString(or, 8);
            }
            if (radioButton3.Checked)
            {
                int pr1 = Convert.ToInt32(textBox1.Text);
                int pr2 = Convert.ToInt32(textBox2.Text);
                int or = pr1 | pr2;
                textBox3.Text = Convert.ToString(or, 10);
            }
            if (radioButton4.Checked)
            {
                int pr1 = Convert.ToInt32(textBox1.Text);
                int pr2 = Convert.ToInt32(textBox2.Text);
                int or = pr1 | pr2;
                textBox3.Text = Convert.ToString(or, 16);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                int pr1 = Convert.ToInt32(textBox1.Text);
                int pr2 = Convert.ToInt32(textBox2.Text);
                int or = pr1 ^ pr2;
                textBox3.Text = Convert.ToString(or, 2);
            }
            if (radioButton2.Checked)
            {
                int pr1 = Convert.ToInt32(textBox1.Text);
                int pr2 = Convert.ToInt32(textBox2.Text);
                int or = pr1 ^ pr2;
                textBox3.Text = Convert.ToString(or, 8);
            }
            if (radioButton3.Checked)
            {
                int pr1 = Convert.ToInt32(textBox1.Text);
                int pr2 = Convert.ToInt32(textBox2.Text);
                int or = pr1 ^ pr2;
                textBox3.Text = Convert.ToString(or, 10);
            }
            if (radioButton4.Checked)
            {
                int pr1 = Convert.ToInt32(textBox1.Text);
                int pr2 = Convert.ToInt32(textBox2.Text);
                int or = pr1 ^ pr2;
                textBox3.Text = Convert.ToString(or, 16);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
                int pr1 = Convert.ToInt32(textBox1.Text);
                int pr2 = Convert.ToInt32(textBox2.Text);
                string BinaryCode1 = Convert.ToString(pr1, 2);
                string str1 = "";
                for (int i = 0; i < BinaryCode1.Length; i++)
                {
                    if (BinaryCode1[i] == '1')
                    {
                        str1 += "0";
                    }
                    if (BinaryCode1[i] == '0')
                    {
                        str1 += "1";
                    }
                }
            string BinaryCode2 = Convert.ToString(pr2, 2);
            string str2 = "";
            for (int i = 0; i < BinaryCode2.Length; i++)
            {
                if (BinaryCode2[i] == '1')
                {
                    str2 += "0";
                }
                if (BinaryCode2[i] == '0')
                {
                    str2 += "1";
                }
            }
            textBox3.Text = str1 + " " + str2;
        }
    }
}
