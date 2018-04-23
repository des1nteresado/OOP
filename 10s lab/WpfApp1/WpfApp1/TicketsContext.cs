using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class TicketsContext : DbContext
    {
        public TicketsContext()
            : base("DbConnection")
        { }

        public DbSet<AirTicket> AirTickets { get; set; }
    }
}
