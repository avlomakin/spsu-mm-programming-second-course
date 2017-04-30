using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    public class UttContext : DbContext
    {
        public UttContext() : base("UttDb")
            { }

        public DbSet<User> Users { get; set; }
        public DbSet<Stat> Stats { get; set; }
    }
}
