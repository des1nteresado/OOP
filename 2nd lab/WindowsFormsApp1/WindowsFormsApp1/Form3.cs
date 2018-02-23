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
            this.Close();
        }
    }
}
