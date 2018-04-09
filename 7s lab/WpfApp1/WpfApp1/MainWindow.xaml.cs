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
using System.Data.Sql;


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
        DataTable LibTable1 = new DataTable();
        DataTable LibTable2 = new DataTable();
        DataTable LibTable3 = new DataTable();



        string connectionString;

        SqlDataAdapter adapter;
        DataTable BooksTable;

        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            BooksGrid.RowEditEnding += BooksGrid_RowEditEnding;

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM Books";
            BooksTable = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(GetSql(), connection);
                adapter = new SqlDataAdapter(command);

                // установка команды на добавление для вызова хранимой процедуры
                adapter.InsertCommand = new SqlCommand("sp_InsertBook", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@UDK", SqlDbType.NVarChar, 50, "UDK"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50, "Name"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Author", SqlDbType.NVarChar, 50, "Author"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Pages", SqlDbType.Int, 0, "Pages"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Year", SqlDbType.Int, 0, "Year"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@DVD", SqlDbType.Bit, 0, "DVD"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@CD", SqlDbType.Bit, 0, "CD"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date", SqlDbType.NVarChar, 50, "Date"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Pubhouse", SqlDbType.NVarChar, 50, "Pubhouse"));

                SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
                parameter.Direction = ParameterDirection.Output;

                connection.Open();
                adapter.Fill(BooksTable);
                BooksGrid.ItemsSource = BooksTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        private void BooksGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            UpdateDB();
        }

        private void UpdateDB()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            adapter.Update(BooksTable);
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
            }

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            checkBox1.IsEnabled = false;
            checkBox2.IsEnabled = false;
        }

        int pageSize = 5; // размер страницы
        int pageNumber = 0; // текущая страница

        private string GetSql()
        {
            return "SELECT * FROM Books ORDER BY Id OFFSET ((" + pageNumber + ") * " + pageSize + ") " +
                "ROWS FETCH NEXT " + pageSize + "ROWS ONLY";
        }

        // обработчик кнопки Вперед
        private void Button5_Click(object sender, EventArgs e)
        {
            if (BooksTable.Rows.Count < pageSize) return;

            pageNumber++;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(GetSql(), connection);

                BooksTable.Rows.Clear();
                adapter.Fill(BooksTable);
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

                BooksTable.Rows.Clear();
                adapter.Fill(BooksTable);
            }
        }

        private void AbProg_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Library version 1.1. Powered by Chernyshev Daniil.");
        }


        private void SortAuthorClick(object sender, EventArgs e)
        {
            System.Data.Linq.DataContext db = new System.Data.Linq.DataContext(connectionString);

            var query = from u in db.GetTable<Book>()
                        orderby u.AuthorFIO
                        select u;

        }

        private void SortYearClick(object sender, EventArgs e)
        {
          
        }



    }
}
