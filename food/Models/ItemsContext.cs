using food;
using food.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace food.Models
{
    public class ItemsContext : DbContext
    {

        private readonly ICurrentUserService currentUserService;
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public ItemsContext() { }
        public ItemsContext(DbContextOptions<ItemsContext> options, ICurrentUserService currentUserService) : base(options)
        {
            this.currentUserService = currentUserService;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-T9M3BST;Initial Catalog=ItemDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ProcessSave();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void ProcessSave()
        {
            var currentTime = DateTimeOffset.UtcNow;
            foreach (var item in ChangeTracker.Entries().Where(e => e.State == EntityState.Added && e.Entity is Entity))
            {
                var entity = item.Entity as Entity;
                entity.CreatedDate = currentTime;
                entity.ModifiedDate = currentTime;
                entity.CreatedByUser = currentUserService.GetCurrentUsername();
                entity.ModifiedByUser = currentUserService.GetCurrentUsername();
            }
            foreach (var item in ChangeTracker.Entries().Where(e => e.State == EntityState.Added && e.Entity is Entity))
            {
                var entity = item.Entity as Entity;
                entity.ModifiedDate = currentTime;
                entity.ModifiedByUser = currentUserService.GetCurrentUsername();
                item.Property(nameof(entity.CreatedDate)).IsModified = false;
                item.Property(nameof(entity.CreatedByUser)).IsModified = false;
            }
        }
    }
}
