using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для PubhouseWindow.xaml
    /// </summary>
    public partial class PubhouseWindow : Window
    {
        public PubhouseWindow()
        {
            InitializeComponent();
            comboBox1.Items.Add("Частное");
            comboBox1.Items.Add("Государтсвенное");
        }
       
        private void Button1_Click(object sender, EventArgs e)
        {
            Pubhouse.Pubname = textBox1.Text;
            Pubhouse.PubCountry = textBox2.Text;
            Pubhouse.PubCity = textBox3.Text;
            Pubhouse.Type = comboBox1.Text;
                this.Close();
        }
    }
}
