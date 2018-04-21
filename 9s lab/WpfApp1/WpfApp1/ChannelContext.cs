using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WpfApp1
{
    class ChannelContext : DbContext
    {
        public ChannelContext()
            : base("DbConnection")
        { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<ChannelImage> ChannelImages { get; set; }
    }
}
