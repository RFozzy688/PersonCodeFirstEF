using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonCodeFirstEF
{
    public class PersonContext : DbContext
    {
        public PersonContext() : base("PersonDB")
        { }
        public DbSet<Person> Persons { get; set; }
    }
}
