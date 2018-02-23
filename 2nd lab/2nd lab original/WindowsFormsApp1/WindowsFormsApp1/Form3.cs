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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            comboBox1.Items.Add("Частное");
            comboBox1.Items.Add("Государтсвенное");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pubhouse.Pubname = textBox1.Text;
            Pubhouse.PubCountry = textBox2.Text;
            Pubhouse.PubCity = textBox3.Text;
            Pubhouse.Type = comboBox1.Text;
            if(errorProvider1.GetError(textBox1) == string.Empty && errorProvider1.GetError(textBox2) == string.Empty && errorProvider1.GetError(textBox3) == string.Empty && errorProvider1.GetError(comboBox1) == string.Empty)
            {
                this.Close();
            }
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                errorProvider1.SetError(textBox1, "Пустая строка!");
            }
            else
            {
                errorProvider1.SetError(textBox1, String.Empty);
            }
        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                errorProvider1.SetError(textBox2, "Пустая строка!");
            }
            else
            {
                errorProvider1.SetError(textBox2, String.Empty);
            }
        }

        private void textBox3_Validated(object sender, EventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {
                errorProvider1.SetError(textBox3, "Пустая строка!");
            }
            else
            {
                errorProvider1.SetError(textBox3, String.Empty);
            }
        }


        private void comboBox1_Validated(object sender, EventArgs e)
        {
            if (comboBox1.Text == string.Empty)
            {
                errorProvider1.SetError(comboBox1, "Пустая строка!");
            }
            if (!(comboBox1.Text.Contains("Частное")) && !(comboBox1.Text.Contains("Государтсвенное")))
            {
                errorProvider1.SetError(comboBox1, "Неверное значение!");
            }
            else
            {
                errorProvider1.SetError(comboBox1, String.Empty);
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                errorProvider1.SetError(textBox1, "Пустая строка!");
            }
            else
            {
                errorProvider1.SetError(textBox1, String.Empty);
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                errorProvider1.SetError(textBox2, "Пустая строка!");
            }
            else
            {
                errorProvider1.SetError(textBox2, String.Empty);
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {
                errorProvider1.SetError(textBox3, "Пустая строка!");
            }
            else
            {
                errorProvider1.SetError(textBox3, String.Empty);
            }
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.Text == string.Empty)
            {
                errorProvider1.SetError(comboBox1, "Пустая строка!");
            }
            if (!(comboBox1.Text.Contains("Частное")) && !(comboBox1.Text.Contains("Государтсвенное")))
            {
                errorProvider1.SetError(comboBox1, "Неверное значение!");
            }
            else
            {
                errorProvider1.SetError(comboBox1, String.Empty);
            }
        }
    }
}
