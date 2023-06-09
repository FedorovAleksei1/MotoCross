using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MotoCross.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Moto> Motoes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<СustomerService> CustomerServices { get; set; }
        public DbSet<InfoUser> Infoes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Important> Importants { get; set; }
    }
}