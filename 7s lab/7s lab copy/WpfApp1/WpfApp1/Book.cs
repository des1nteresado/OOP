using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Book
    {
        public Book() { }
        public string Name { get; set; }
        public string Udk { get; set; }
        public int Pages { get; set; }
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
}
