using Microsoft.EntityFrameworkCore;
using static System.Console;

namespace Packt.Shared
{
    public class Northwind : DbContext
    {
        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = @"Data Source=(localDB)\mssqllocaldb;" +
                                "database=Northwind;" +
                                "Integrated Security=true;" +
                                "MultipleActiveResultSets=true;";
            optionsBuilder.UseSqlServer(connection);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().Property(category => category.CategoryName).IsRequired().HasMaxLength(15);
            
        }
    }
}
