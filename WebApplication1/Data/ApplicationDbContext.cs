using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MotoCross.Models;

namespace MotoCross.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Moto> Motos { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<СustomerServiceDto> CustomerServices { get; set; }
    }
}