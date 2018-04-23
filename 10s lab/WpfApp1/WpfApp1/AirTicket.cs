using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class AirTicket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Type { get; set; }
        public int Count { get; set; }

        public AirTicket(int id, string title, string date, string type, int count)
        {
            this.Id = id;
            this.Title = title;
            this.Date = date;
            this.Type = type;
            this.Count = count;
        }

        public AirTicket()
        {

        }
    }
}
