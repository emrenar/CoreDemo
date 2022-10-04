using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAccessLayer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // Optionsbuilder parametre türü dbcontext Oluşturucusuna ihtiyaç duyarız
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=CoreBlogApiDb;integrated security=true;");

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
