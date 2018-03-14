using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

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
    [MetadataType(typeof(Book))]
    [Serializable]
    public class Book
    {
        public Book() { }
        public string Name { get; set; }
        public string Udk { get; set; }
        public int Pages { get; set; }
        public int Year { get; set; }
        public bool Cd { get; set; }
        public bool Dvd { get; set; }
        public string Date { get; set; }
        [UserName]
        public string AuthorFIO { get; set; }
        [UserName]
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
    public class UserNameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string AuthorFIO = value.ToString();
                if (!AuthorFIO.StartsWith("Ъ") && !AuthorFIO.StartsWith("Ь"))
                    return true;
                else
                    this.ErrorMessage = "Имя не должно начинаться с буквы Ъ/Ь";
            }
            return false;
        }
    }
}

