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
            this.Close();
        }
    }
}
