using Microsoft.EntityFrameworkCore;
using UberEats.Domain.Bill;
using UberEats.Domain.Common.Models;
using UberEats.Domain.Dinner;
using UberEats.Domain.Guest;
using UberEats.Domain.Host;
using UberEats.Domain.MenuReview;
using UberEats.Domain.Menus;
using UberEats.Domain.User;
using UberEats.Infrastructure.Persistence.Interceptors;

namespace UberEats.Infrastructure.Persistence
{
    public sealed class UberEatsDbContext : DbContext
    {
        private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;
        public UberEatsDbContext(DbContextOptions<UberEatsDbContext> options,PublishDomainEventsInterceptor publishDomainEventsInterceptor) : base(options)
        {
            _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
        }
        public DbSet<Bill> Bills { get; set; } = null;
        public DbSet<Dinner> Dinners { get; set; } = null;
        public DbSet<Guest> Guests { get; set; } = null;
        public DbSet<Host> Hosts { get; set; } = null;
        public DbSet<Menu> Menus { get; set; } = null;
        public DbSet<MenuReview> MenuReviews { get; set; } = null;
        public DbSet<User> Users { get; set; } = null;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Ignore<List<IDomainEvent>>()
                .ApplyConfigurationsFromAssembly(typeof(UberEatsDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .AddInterceptors(_publishDomainEventsInterceptor);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
