
using WebApplication3.Entities;
using Microsoft.EntityFrameworkCore;


namespace WebApplication3.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<APPUSER> APPUSERs { get; set; }
        
    }
    
}
