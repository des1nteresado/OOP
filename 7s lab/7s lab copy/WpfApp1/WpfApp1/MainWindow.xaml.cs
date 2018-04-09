using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string info = "";
        string sqlExpAuthors = "";
        string sqlExpBooks = "";
        string sqlExpPubhouses = "";
        string sql1 = "SELECT * FROM Books";
        string sql2 = "SELECT * FROM Authors";
        string sql3 = "SELECT * FROM Pubhouses";
        SqlDataAdapter adapter;
        DataTable LibTable1 = new DataTable();
        DataTable LibTable2 = new DataTable();
        DataTable LibTable3 = new DataTable();


        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


        public MainWindow()
        {
            InitializeComponent();
            textBox5.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                MessageBox.Show("Подключение открыто");
                info += "\tСтрока подключения: " + connection.ConnectionString;
                info += "\n\tБаза данных: " + connection.Database;
                info += "\n\tСервер: " + connection.DataSource;
                info += "\n\tВерсия сервера: " + connection.ServerVersion;
                info += "\n\tСостояние: " + connection.State;
                info += "\n\tWorkstationld: " + connection.WorkstationId;
            }
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, connection);
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, connection);
                SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, connection);

                // Заполняем Dataset
                adapter1.Fill(LibTable1);
                adapter2.Fill(LibTable2);
                adapter3.Fill(LibTable3);

                // Отображаем данные
                BooksGrid.ItemsSource = LibTable1.DefaultView;
                AuthorsGrid.ItemsSource = LibTable2.DefaultView;
                PubGrid.ItemsSource = LibTable3.DefaultView;

            }
            //ConnectWithDB().GetAwaiter();
            textBox5.Text += info;
        }

        private void UpdateDB()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, connection);
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, connection);
                SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, connection);

                // Создаем объект Dataset
                // Заполняем Dataset

                adapter1.Update(LibTable1);
                adapter2.Update(LibTable2);
                adapter3.Update(LibTable3);

                // Отображаем данные
                BooksGrid.ItemsSource = LibTable1.DefaultView;
                AuthorsGrid.ItemsSource = LibTable2.DefaultView;
                PubGrid.ItemsSource = LibTable3.DefaultView;

            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDB();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (BooksGrid.SelectedItems != null)
            {
                for (int i = 0; i < BooksGrid.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = BooksGrid.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
            UpdateDB();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AuthorWindow author = new AuthorWindow();
            author.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            PubhouseWindow pubhouse = new PubhouseWindow();
            pubhouse.Show();
        }


        private void Button3_Click(object sender, EventArgs e)
        {
            int cd = 0;
            int dvd = 0;
            Book book = new Book();
            book.Name = textBox1.Text;
            book.Udk = textBox2.Text;
            book.Year = int.Parse(textBox3.Text);
            book.Pages = int.Parse(textBox4.Text);
            if (checkBox1.IsEnabled)
            {
                book.Cd = true;
                cd = 1;
            }
            if (checkBox2.IsEnabled)
            {
                book.Dvd = true;
                dvd = 1;
            }
            book.Date = dateTimePicker1.Text;
            book.AuthorFIO = Author.AuthorFIO;
            book.AuthorCountry = Author.AuthorCountry;
            book.AuthorSex = Author.AuthorSex;
            book.Pubname = Pubhouse.Pubname;
            book.PubCountry = Pubhouse.PubCountry;
            book.PubCity = Pubhouse.PubCity;
            book.Type = Pubhouse.Type;
            Box.box.Add(book);
            textBox5.Clear();

            sqlExpAuthors = String.Format("INSERT INTO Authors (УДК, ФИО, Страна, Пол) VALUES ({0}, '{1}', '{2}', '{3}')", book.Udk, book.AuthorFIO, book.AuthorCountry, book.AuthorSex);
            sqlExpBooks = String.Format("INSERT INTO Books (УДК, Название, Страницы, Годизд, DVD, CD, Датапост)" +
                " VALUES ({0}, '{1}', {2}, {3}, {4}, {5}, '{6}')", book.Udk, book.Name, book.Pages, book.Year, dvd, cd, book.Date);
            sqlExpPubhouses = String.Format("INSERT INTO Pubhouses (УДК, Название, Страна, Город, Тип) " +
                "VALUES ({0}, '{1}', '{2}', '{3}', '{4}')", book.Udk, book.Pubname, book.PubCountry, book.PubCity, book.Type);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpAuthors, connection);
                SqlCommand command1 = new SqlCommand(sqlExpBooks, connection);
                SqlCommand command2 = new SqlCommand(sqlExpPubhouses, connection);
                int number = command.ExecuteNonQuery();
                int number1 = command1.ExecuteNonQuery();
                int number2 = command2.ExecuteNonQuery();

                textBox5.Text += "Книга добавлена" + Environment.NewLine;
            }
    
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            checkBox1.IsEnabled = false;
            checkBox2.IsEnabled = false;
        }

        int pageSize = 1; // размер страницы
        int pageNumber = 0; // текущая страница
        DataSet ds;

        private string GetSql()
        {
            return "SELECT * FROM Books ORDER BY УДК OFFSET ((" + pageNumber + ") * " + pageSize + ") " +
                "ROWS FETCH NEXT " + pageSize + "ROWS ONLY";
        }

        // обработчик кнопки Вперед
        private void Button5_Click(object sender, EventArgs e)
        {
            if (ds.Tables["Books"].Rows.Count < pageSize) return;

            pageNumber++;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(GetSql(), connection);

                ds.Tables["Books"].Rows.Clear();

                adapter.Fill(ds, "Books");
            }
        }
        // обработчик кнопки Назад

        private void Button4_Click(object sender, EventArgs e)
        {
            if (pageNumber == 0) return;
            pageNumber--;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(GetSql(), connection);

                ds.Tables["Books"].Rows.Clear();

                adapter.Fill(ds, "Books");
            }
        }

        private void AbProg_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Library version 1.1. Powered by Chernyshev Daniil.");
        }


        private void SortAuthorClick(object sender, EventArgs e)
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

        private void SortYearClick(object sender, EventArgs e)
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

        private void Button6_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("books.xml", FileMode.Create))
            {
                textBox5.Clear();
                textBox5.Text += "XML файл очищен.";
            }
        }

    }
}
