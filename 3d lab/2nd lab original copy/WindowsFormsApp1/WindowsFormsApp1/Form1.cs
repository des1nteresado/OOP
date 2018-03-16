using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Xml;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        bool chck1 = false;
        bool chck2 = false;
        bool chck3 = false;
        bool valid = false;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();
            trackBar1.Maximum = 1500;
            trackBar1.Minimum = 1;
            trackBar1.Scroll += trackBar1_Scroll;
            textBox5.ScrollBars = ScrollBars.Vertical;

        }
        private static void Validate(Book book, ref bool valid)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(book);
            if (!Validator.TryValidateObject(book, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                    MessageBox.Show(error.ErrorMessage);
                    valid = true;
                }
            }
        }
        private static void ChangeTime(object c)
        {

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
            if (checkBox1.Checked)
            {
                book.Cd = true;
            }
            if (checkBox2.Checked)
            {
                book.Dvd = true;
            }
            book.Date = dateTimePicker1.Text;

            while (!chck3)
            {
                if (chck1 && chck2)
                {
                    valid = false;
                    book.AuthorFIO = Author.AuthorFIO;
                    book.AuthorCountry = Author.AuthorCountry;
                    book.AuthorSex = Author.AuthorSex;
                    book.Pubname = Pubhouse.Pubname;
                    book.PubCountry = Pubhouse.PubCountry;
                    book.PubCity = Pubhouse.PubCity;
                    book.Type = Pubhouse.Type;
                    Validate(book, ref valid);
                    if (!valid)
                    {
                        Box.box.Add(book);
                        textBox5.Clear();
                        foreach (Book bk in Box.box)
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
                    }
                    else
                    {
                        textBox5.Clear();
                        textBox5.Text += "Книга не добавлена. Исправьте ошибки.";
                    }
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
            XmlSerializer formatter1 = new XmlSerializer(typeof(List<Book>));
            using (FileStream fs = new FileStream("books.xml", FileMode.OpenOrCreate))
            {
                bool ur = true;
                if (fs.Length == 0)
                {
                    MessageBox.Show("Файл пуст.");
                    ur = false;
                }
                if (ur)
                {
                    textBox5.Clear();
                    Box.box = (List<Book>)formatter1.Deserialize(fs);
                    foreach (Book bk in Box.box)
                    {
                        textBox5.Text += "Название: " + bk.Name + Environment.NewLine + "УДК: " + bk.Udk + Environment.NewLine + "Год издания: " + bk.Year + Environment.NewLine + "Кол.во страниц: " + bk.Pages + Environment.NewLine + "Наличие CD, DVD: " + bk.Cd + "," + bk.Dvd + Environment.NewLine + "Дата поступления: " + bk.Date + Environment.NewLine;
                        textBox5.Text += "Автор: " + bk.AuthorFIO + Environment.NewLine + "Страна: " + bk.AuthorCountry + Environment.NewLine + "Пол: " + bk.AuthorSex + Environment.NewLine;
                        textBox5.Text += "Издательство: " + bk.Pubname + Environment.NewLine + "Страна: " + bk.PubCountry + Environment.NewLine + "Город: " + bk.PubCity + Environment.NewLine + "Тип: " + bk.Type + Environment.NewLine;
                    }
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

        private void поискПоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Searchpbhouse form = new Searchpbhouse();
            form.Show();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Library version 1.1. Powered by Chernyshev Daniil.");
        }

        private void поГодуИзданияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Searchbydate form = new Searchbydate();
            form.Show();
        }

        private void поДиапозонуСтраницToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Searchbypages form = new Searchbypages();
            form.Show();
        }

        private void поЧастиИмениToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Searchbyname form = new Searchbyname();
            form.Show();
        }

        private void поГодуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool ur = true;
            textBox5.Clear();
            string book = "books.xml";
            using (FileStream fs = new FileStream("books.xml", FileMode.OpenOrCreate))
            {
                if (fs.Length == 0)
                {
                    MessageBox.Show("Файл пуст.");
                    ur = false;
                }
            }
            if (ur)
            {
                XDocument doc = XDocument.Load(book);
                List<Book> Sorter = new List<Book>();
                var items = from xe in doc.Root.Elements("Book")
                            orderby xe.Element("AuthorFIO").Value
                            select xe;
                foreach (var bk in items)
                {
                    textBox5.Text += "Название: " + bk.Element("Name").Value + Environment.NewLine + "УДК: " + bk.Element("Udk").Value + Environment.NewLine + "Год издания: " + bk.Element("Year").Value + Environment.NewLine + "Кол.во страниц: " + bk.Element("Pages").Value + Environment.NewLine + "Наличие CD, DVD: " + bk.Element("Cd").Value + "," + bk.Element("Dvd").Value + Environment.NewLine + "Дата поступления: " + bk.Element("Date").Value + Environment.NewLine;
                    textBox5.Text += "Автор: " + bk.Element("AuthorFIO").Value + Environment.NewLine + "Страна: " + bk.Element("AuthorCountry").Value + Environment.NewLine + "Пол: " + bk.Element("AuthorSex").Value + Environment.NewLine;
                    textBox5.Text += "Издательство: " + bk.Element("Pubname").Value + Environment.NewLine + "Страна: " + bk.Element("PubCountry").Value + Environment.NewLine + "Город: " + bk.Element("PubCity").Value + Environment.NewLine + "Тип: " + bk.Element("Type").Value + Environment.NewLine;
                }
                var box = from t in Box.box
                          orderby t.AuthorFIO
                          select t;
                foreach (var bk in box)
                {
                    Sorter.Add(bk);
                }
                XmlSerializer formatter1 = new XmlSerializer(typeof(List<Book>));
                using (FileStream fs = new FileStream("books.xml", FileMode.OpenOrCreate))
                {
                    formatter1.Serialize(fs, Sorter);
                }
                MessageBox.Show("Сортировка по году успешно выполнена! Файл перезаписан.");
            }

        }

        private void поФамилииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
            bool ur = true;
            string book = "books.xml";
            List<Book> Sorter = new List<Book>();
            using (FileStream fs = new FileStream("books.xml", FileMode.OpenOrCreate))
            {
                if (fs.Length == 0)
                {
                    MessageBox.Show("Файл пуст.");
                    ur = false;
                }
            }
            if (ur)
            {
                XDocument doc = XDocument.Load(book);
                var items = from xe in doc.Root.Elements("Book")
                            orderby int.Parse(xe.Element("Year").Value)
                            select xe;
                foreach (var bk in items)
                {
                    textBox5.Text += "Название: " + bk.Element("Name").Value + Environment.NewLine + "УДК: " + bk.Element("Udk").Value + Environment.NewLine + "Год издания: " + bk.Element("Year").Value + Environment.NewLine + "Кол.во страниц: " + bk.Element("Pages").Value + Environment.NewLine + "Наличие CD, DVD: " + bk.Element("Cd").Value + "," + bk.Element("Dvd").Value + Environment.NewLine + "Дата поступления: " + bk.Element("Date").Value + Environment.NewLine;
                    textBox5.Text += "Автор: " + bk.Element("AuthorFIO").Value + Environment.NewLine + "Страна: " + bk.Element("AuthorCountry").Value + Environment.NewLine + "Пол: " + bk.Element("AuthorSex").Value + Environment.NewLine;
                    textBox5.Text += "Издательство: " + bk.Element("Pubname").Value + Environment.NewLine + "Страна: " + bk.Element("PubCountry").Value + Environment.NewLine + "Город: " + bk.Element("PubCity").Value + Environment.NewLine + "Тип: " + bk.Element("Type").Value + Environment.NewLine;

                }
                var box = from t in Box.box
                          orderby t.Year
                          select t;
                foreach (var bk in box)
                {
                    Sorter.Add(bk);
                }
                XmlSerializer formatter1 = new XmlSerializer(typeof(List<Book>));
                using (FileStream fs = new FileStream("books.xml", FileMode.OpenOrCreate))
                {
                    formatter1.Serialize(fs, Sorter);
                }
                MessageBox.Show("Сортировка по авторам успешно выполнена! Файл перезаписан.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("books.xml", FileMode.Create))
            {
                textBox5.Clear();
                textBox5.Text += "XML файл очищен.";
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
            ToolTip t = new ToolTip();
            t.SetToolTip(button8, "Сортировка по автору");
            t.SetToolTip(button9, "Сортировка по году издания");
            t.SetToolTip(button7, "Чистка буфера и XML файла.");
        }
       

        private void timer1_Tick(object sender, EventArgs e)
        {
            int h = DateTime.Now.Hour;
            int m = DateTime.Now.Minute;
            int s = DateTime.Now.Second;

            string time = "";
            if (h < 10)
            {
                time += "0" + h;
            }
            else
            {
                time += h;
            }

            time += ":";

            if (m < 10)
            {
                time += "0" + m;
            }
            else
            {
                time += m;
            }

            time += ":";

            if (s < 10)
            {
                time += "0" + s;
            }
            else
            {
                time += s;
            }
            label6.Text = time;
            string data = "";

            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            if (day < 10)
            {
                data += "0" + day;
            }
            else
            {
                data += day;
            }
            data += ".";
            if (month < 10)
            {
                data += "0" + month;
            }
            else
            {
                data += month;
            }
            data += ".";
            data += year;
            label7.Text = data;
            label8.Text = "Текущее кол.во объектов в буфере: " + Box.box.Count();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("books.xml", FileMode.Create))
            {
                textBox5.Clear();
                textBox5.Text += "XML файл очищен.";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
        }

        private void panel1_DragOver(object sender, DragEventArgs e)
        {
        }
        bool isDown;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isDown = true;
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
        }


        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            if (isDown && checkBox3.Checked)
            {

                c.Location = this.PointToClient(Control.MousePosition);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
