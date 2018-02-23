using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        bool chck1 = false;
        bool chck2 = false;
        bool chck3 = false;

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
            Book book = new Book();
            chck3 = false;
            book.Name = textBox1.Text;
            book.Udk = textBox2.Text;
            book.Year = int.Parse(textBox3.Text);
            book.Pages = int.Parse(textBox4.Text);
            if(checkBox1.Checked)
            {
                book.Cd = true;
            }
            if(checkBox2.Checked)
            {
                book.Dvd = true;
            }
            book.Date = dateTimePicker1.Text;
           
            while (!chck3)
            {
                if (chck1 && chck2)
                {
                    book.AuthorFIO = Author.AuthorFIO;
                    book.AuthorCountry = Author.AuthorCountry;
                    book.AuthorSex = Author.AuthorSex;
                    book.Pubname = Pubhouse.Pubname;
                    book.PubCountry = Pubhouse.PubCountry;
                    book.PubCity = Pubhouse.PubCity;
                    book.Type = Pubhouse.Type;
                    Box.box.Add(book);
                    textBox5.Clear();
                    foreach(Book bk in Box.box)
                    {
                        textBox5.Text += "Название: " + bk.Name + Environment.NewLine + "УДК: " + bk.Udk + Environment.NewLine + "Год издания: " + bk.Year + Environment.NewLine + "Кол.во страниц: " + bk.Pages + Environment.NewLine + "Наличие CD, DVD: " + bk.Cd + "," + bk.Dvd + Environment.NewLine + "Дата поступления: " + bk.Date + Environment.NewLine;
                        textBox5.Text += "Автор: " + bk.AuthorFIO + Environment.NewLine + "Страна: " + bk.AuthorCountry + Environment.NewLine + "Пол: " + bk.AuthorSex + Environment.NewLine;
                        textBox5.Text += "Издательство: " + bk.Pubname + Environment.NewLine + "Страна: " + bk.PubCountry + Environment.NewLine + "Город: " + bk.PubCity + Environment.NewLine + "Тип: " + bk.Type + Environment.NewLine;
                    }
                    #region try
                    //for(int c = 0; c < i; c++)
                    //{
                    //textBox5.Text += "Название: " + Library.books[c].Name + Environment.NewLine + "УДК: " + Library.books[c].Udk + Environment.NewLine + "Год издания: " + Library.books[c].Year + Environment.NewLine + "Кол.во страниц: " + Library.books[c].Pages + Environment.NewLine + "Наличие CD, DVD: " + Library.books[c].Cd + "," + Library.books[c].Dvd + Environment.NewLine + "Дата поступления: " + Library.books[c].Date + Environment.NewLine;
                    //textBox5.Text += "Автор: " + Authors.authors[c].Fio + Environment.NewLine + "Страна: " + Authors.authors[c].Country + Environment.NewLine + "Пол: " + Authors.authors[c].Sex + Environment.NewLine;
                    //textBox5.Text += "Издательство: " + PubHouses.pubhouses[c].Name + Environment.NewLine + "Страна: " + PubHouses.pubhouses[c].Country + Environment.NewLine + "Город: " + PubHouses.pubhouses[c].City + Environment.NewLine + "Тип: " + PubHouses.pubhouses[c].Type + Environment.NewLine;
                    //}
                    //foreach (Book bk in Library.books)
                    //{
                    //    textBox5.Text += "Название: " + bk.Name + Environment.NewLine + "УДК: " + bk.Udk + Environment.NewLine + "Год издания: " + bk.Year + Environment.NewLine + "Кол.во страниц: " + bk.Pages + Environment.NewLine + "Наличие CD, DVD: " + bk.Cd + "," + bk.Dvd + Environment.NewLine + "Дата поступления: " + bk.Date + Environment.NewLine;
                    //}
                    //foreach (Book.Author ba in Authors.authors)
                    //{
                    //    textBox5.Text += "Автор: " + ba.Fio + Environment.NewLine + "Страна: " + ba.Country + Environment.NewLine + "Пол: " + ba.Sex + Environment.NewLine;
                    //}
                    //foreach (Book.PubHouse ba in PubHouses.pubhouses)
                    //{
                    //    textBox5.Text += "Издательство: " + ba.Name + Environment.NewLine + "Страна: " + ba.Country + Environment.NewLine + "Город: " + ba.City + Environment.NewLine + "Тип: " + ba.Type + Environment.NewLine;
                    //}
                    #endregion
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
                    MessageBox.Show("Книга не была добавлена. Укажите сведения о авторе и издательстве.");
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

        private void button5_Click(object sender, EventArgs e)
        {
            #region tryjson
            //DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Book[]));
            //using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            //{
            //    jsonFormatter.WriteObject(fs, Library.book);
            //}
            //using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            //{
            //    Book[] newpeople = (Book[])jsonFormatter.ReadObject(fs);
            //}
            //DataContractJsonSerializer jsonFormatter2 = new DataContractJsonSerializer(typeof(Book.Author[]));
            //using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            //{
            //    jsonFormatter2.WriteObject(fs, Authors.author);
            //}
            //using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            //{
            //    Book.Author[] newpeople = (Book.Author[])jsonFormatter2.ReadObject(fs);
            //}
            //DataContractJsonSerializer jsonFormatter3 = new DataContractJsonSerializer(typeof(Book.PubHouse[]));
            //using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            //{
            //    jsonFormatter3.WriteObject(fs, PubHouses.pubhouse);
            //}
            //using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            //{
            //    Book.PubHouse newpeople = (Book.PubHouse)jsonFormatter3.ReadObject(fs);
            //}
            #endregion

            XmlSerializer formatter1 = new XmlSerializer(typeof(List<Book>));

            using (FileStream fs = new FileStream("books.xml", FileMode.OpenOrCreate))
            {
                formatter1.Serialize(fs, Box.box);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Book book = new Book();

            XmlSerializer formatter1 = new XmlSerializer(typeof(List<Book>));
            using (FileStream fs = new FileStream("books.xml", FileMode.OpenOrCreate))
            {
                Box.box = (List<Book>)formatter1.Deserialize(fs);
                textBox5.Clear();
                foreach (Book bk in Box.box)
                {
                    textBox5.Text += "Название: " + bk.Name + Environment.NewLine + "УДК: " + bk.Udk + Environment.NewLine + "Год издания: " + bk.Year + Environment.NewLine + "Кол.во страниц: " + bk.Pages + Environment.NewLine + "Наличие CD, DVD: " + bk.Cd + "," + bk.Dvd + Environment.NewLine + "Дата поступления: " + bk.Date + Environment.NewLine;
                    textBox5.Text += "Автор: " + bk.AuthorFIO + Environment.NewLine + "Страна: " + bk.AuthorCountry + Environment.NewLine + "Пол: " + bk.AuthorSex + Environment.NewLine;
                    textBox5.Text += "Издательство: " + bk.Pubname + Environment.NewLine + "Страна: " + bk.PubCountry + Environment.NewLine + "Город: " + bk.PubCity + Environment.NewLine + "Тип: " + bk.Type + Environment.NewLine;
                }
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

        private void textBox4_Validated(object sender, EventArgs e)
        {
            if ((textBox4.Text == string.Empty))
            {
                errorProvider1.SetError(textBox4, "Пустая строка!");
            }
            else
            {
                errorProvider1.SetError(textBox4, String.Empty);
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (textBox4.Text == string.Empty)
            {
                errorProvider1.SetError(textBox4, "Пустая строка!");
            }
            else
            {
                errorProvider1.SetError(textBox4, String.Empty);
            }
        }
    }
}
