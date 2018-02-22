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
        List<Book> books = new List<Book>();
        List<Book.Author> authors = new List<Book.Author>();
        List<Book.PubHouse> pubhouses = new List<Book.PubHouse>();
        Book[] book = new Book[100];
        Book.Author[] author = new Book.Author[100];
        Book.PubHouse[] pubhouse = new Book.PubHouse[100];

        int i = 0;
        bool chck1 = false;
        bool chck2 = false;
        bool chck3 = false;
        class Book
        {
            private string name;
            private string udk;
            private int pages;
            private int year;
            private bool cd;
            private bool dvd;
            private string date;
            public string Name { get; set; }
            public string Udk { get; set; }
            public int Pages
            {
                get
                {
                    return pages;
                }
                set
                {
                    if(value > 0)
                    {
                        pages = value;
                    }
                }
            }
            public int Year { get; set; }
            public bool Cd { get; set; }
            public bool Dvd { get; set; }
            public string Date { get; set; }
            public class Author
            {
                private string fio;
                private string country;
                private string sex;
                public string Fio { get; set; }
                public string Country { get; set; }
                public string Sex { get; set; }
            }
            public class PubHouse
            {
                private string name;
                private string country;
                private string city;
                private int year;
                private string type;
                public string Name { get; set; }
                public string Country { get; set; }
                public string City { get; set; }
                public int Year { get; set; }
                public string Type { get; set; }
            }

        }
        public Form1()
        {
            InitializeComponent();
            trackBar1.Maximum = 1500;
            trackBar1.Minimum = 1;
            trackBar1.Scroll += trackBar1_Scroll;
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            chck1 = true;
            form2.Show();
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            chck2 = true;
            form3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            book[i] = new Book();
            chck3 = false;
            book[i].Name = textBox1.Text;
            book[i].Udk = textBox2.Text;
            book[i].Year = int.Parse(textBox3.Text);
            book[i].Pages = int.Parse(textBox4.Text);
            if(checkBox1.Checked)
            {
                book[i].Cd = true;
            }
            if(checkBox2.Checked)
            {
                book[i].Dvd = true;
            }
            book[i].Date = dateTimePicker1.Text;
            Form2 form2 = new Form2();
            author[i] = new Book.Author();
            author[i].Fio = form2.Fio;
            form2.Fio = "ну епт";
            MessageBox.Show(form2.Fio);
            author[i].Country = form2.Textbox2;
            author[i].Sex = form2.Combobox1;
            authors.Add(author[i]);
            while (!chck3)
            {
                if (chck1 && chck2)
                {
                    books.Add(book[i]);
                    i++;
                    textBox5.Clear();
                    foreach (Book bk in books)
                    {
                        textBox5.Text += "Название: " + bk.Name + Environment.NewLine + "УДК: " + bk.Udk + Environment.NewLine + "Год издания: " + bk.Year + Environment.NewLine + "Кол.во страниц: " + bk.Pages + Environment.NewLine + "Наличие CD, DVD: " + bk.Cd + "," + bk.Dvd + Environment.NewLine + "Дата поступления: " + bk.Date + Environment.NewLine;
                    }
                    foreach (Book.Author ba in authors)
                    {
                        textBox5.Text += "Автор: " + ba.Fio + Environment.NewLine + "Страна: " + ba.Country + Environment.NewLine + "Пол: " + ba.Sex + Environment.NewLine;
                    }
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    chck3 = true;
                    chck1 = false;
                    chck2 = false;
                    break;
                }
                else
                {
                    MessageBox.Show("Книга не была добавлены! Укажите сведения о авторе и издательстве.");
                    break;
                }
            }
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox4.Text = trackBar1.Value.ToString();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
