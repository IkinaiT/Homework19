using Homework19.Models;
using Microsoft.EntityFrameworkCore;

namespace Hommework19.DataBase
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public DataBaseContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
