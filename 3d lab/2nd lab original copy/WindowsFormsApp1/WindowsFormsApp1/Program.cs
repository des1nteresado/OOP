using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    [Serializable]
    public class Book
    {
        public Book() { }
        public string Name { get; set; }
        public string Udk { get; set; }
        private int pages;
        public int Pages
        {
            get
            {
                return pages;
            }
            set
            {
                if (value > 0)
                {
                    pages = value;
                }
            }
        }
        public int Year { get; set; }
        public bool Cd { get; set; }
        public bool Dvd { get; set; }
        public string Date { get; set; }
        public string AuthorFIO { get; set; }
        public string AuthorCountry { get; set; }
        public string AuthorSex { get; set; }
        public string Pubname { get; set; }
        public string PubCountry { get; set; }
        public string PubCity { get; set; }
        public string Type { get; set; }
    }
    static class Author
    {
        public static string AuthorFIO { get; set; }
        public static string AuthorCountry { get; set; }
        public static string AuthorSex { get; set; }
    }
    static class Pubhouse
    {
        public static string Pubname { get; set; }
        public static string PubCountry { get; set; }
        public static string PubCity { get; set; }
        public static string Type { get; set; }

    }
    static class Box
    {
        public static List<Book> box = new List<Book>();
    }
}
