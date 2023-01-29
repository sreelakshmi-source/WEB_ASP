using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Detail> Detail { get; set; }
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options):base (options)
        {
            
        }
    }
}
