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

        public DbSet<EntityMoto> Motoes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<СustomerService> CustomerServices { get; set; }
        public DbSet<InfoUser> Infoes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Important> Importants { get; set; }
        public DbSet<CardTeamUser> CardTeamUsers { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<FormedTeam> FormedTeams { get; set; }
        public DbSet<Balans> Balanses { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationUser> OperationsUser { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardUser> CardsUser { get; set; }
        public DbSet<CardNameOnputMoney> CardNamePutMoneys { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CardNameOnputMoney>()
                .HasIndex(x => x.CardId)
                .HasName("IX_CardNamePutMoneys_CardId")
                .IsUnique(false);
        }
    }
}