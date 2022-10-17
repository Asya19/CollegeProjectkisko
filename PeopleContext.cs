using System;
using System.Data.Entity;

namespace WpfApp2
{
    public class PeopleContext : DbContext
    {
        public PeopleContext() : base("DbConnectionString")
        {

        }

        public DbSet<Person> Persons { get; set; }
    }
}
