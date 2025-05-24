using Microsoft.EntityFrameworkCore;

namespace SafeVillage.UserModule;
internal class UserContext(DbContextOptions<UserContext> options) : DbContext(options)
{
    public DbSet<AppUser> Users { get; set; }
    public DbSet<AppRole> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AppRole>()
            .HasKey(e => e.Name);
    }
}
