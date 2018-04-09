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
    /// Логика взаимодействия для AuthorWindow.xaml
    /// </summary>
    public partial class AuthorWindow : Window
    {
        public AuthorWindow()
        {
            InitializeComponent();
            comboBox1.Items.Add("Мужчина");
            comboBox1.Items.Add("Женщина");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Author.AuthorFIO = textBox1.Text;
            Author.AuthorCountry = textBox2.Text;
            Author.AuthorSex = comboBox1.Text;
            this.Close();
        }

    }
}
