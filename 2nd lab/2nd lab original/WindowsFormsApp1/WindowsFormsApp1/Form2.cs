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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            comboBox1.Items.Add("Мужчина");
            comboBox1.Items.Add("Женщина");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Author.AuthorFIO = textBox1.Text;
            Author.AuthorCountry = textBox2.Text;
            Author.AuthorSex = comboBox1.Text;
            if (errorProvider1.GetError(textBox1) == string.Empty && errorProvider1.GetError(textBox2) == string.Empty && errorProvider1.GetError(comboBox1) == string.Empty)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_Validated(object sender, EventArgs e)
        {
            if (comboBox1.Text == string.Empty)
            {
                errorProvider1.SetError(comboBox1, "Пустая строка!");
            }
            if (!(comboBox1.Text.Contains("Мужчина")) && !(comboBox1.Text.Contains("Женщина")))
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

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.Text == string.Empty)
            {
                errorProvider1.SetError(comboBox1, "Пустая строка!");
            }
            else
            {
                errorProvider1.SetError(comboBox1, String.Empty);
            }
        }
    }
}
