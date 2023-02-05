using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;
namespace BulkyBookWeb.Data
{
    public class ApplicationDbContext:DbContext
    {

        //constructor create to establish configuration
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        //it will creat category table in database with the catagery mobile properties
        public DbSet<Category> Categories { get; set; }
    }
}
