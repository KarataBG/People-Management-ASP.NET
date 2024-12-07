using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class InMemoryDB : DbContext
    {

        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("DbPeople");
        }
    }
}
