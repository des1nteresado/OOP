using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class Searchbyname : Form
    {
        public Searchbyname()
        {
            InitializeComponent();
            textBox1.Click += textBox1_Click;
            textBox2.ScrollBars = ScrollBars.Vertical;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            List<Book> Searcher = new List<Book>();
            bool test = true;
            Regex regex = new Regex(@"" + textBox1.Text + "(\\w*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            XmlSerializer formatter1 = new XmlSerializer(typeof(List<Book>));
            using (FileStream fs = new FileStream("books.xml", FileMode.OpenOrCreate))
            {
                Box.box = (List<Book>)formatter1.Deserialize(fs);
                foreach (Book bk in Box.box)
                {
                    if (regex.IsMatch(bk.Name))
                    {
                        test = false;
                        textBox2.Text += "Название: " + bk.Name + Environment.NewLine + "УДК: " + bk.Udk + Environment.NewLine + "Год издания: " + bk.Year + Environment.NewLine + "Кол.во страниц: " + bk.Pages + Environment.NewLine + "Наличие CD, DVD: " + bk.Cd + "," + bk.Dvd + Environment.NewLine + "Дата поступления: " + bk.Date + Environment.NewLine;
                        textBox2.Text += "Автор: " + bk.AuthorFIO + Environment.NewLine + "Страна: " + bk.AuthorCountry + Environment.NewLine + "Пол: " + bk.AuthorSex + Environment.NewLine;
                        textBox2.Text += "Издательство: " + bk.Pubname + Environment.NewLine + "Страна: " + bk.PubCountry + Environment.NewLine + "Город: " + bk.PubCity + Environment.NewLine + "Тип: " + bk.Type + Environment.NewLine;
                        Searcher.Add(bk);
                    }
                }
            }
            if (test)
            {
                textBox2.Text += "Не найдено!";
            }
            if (!test)
            {
                XmlSerializer formatter2 = new XmlSerializer(typeof(List<Book>));
                using (FileStream fs2 = new FileStream("Search by name.xml", FileMode.OpenOrCreate))
                {
                    formatter2.Serialize(fs2, Searcher);
                }
                MessageBox.Show("Поиск успешен! Запись выполнена!");
            }
        }
    }
}
