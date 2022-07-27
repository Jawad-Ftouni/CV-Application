using Microsoft.EntityFrameworkCore;
using CVs.Model;
namespace CVs.Data
{
    public class AppDataBaseContext : DbContext
    {
        public AppDataBaseContext(DbContextOptions<AppDataBaseContext> option) : base(option)
        {

        }

        public DbSet<Programmer> Programer { get; set; }
    }
}
