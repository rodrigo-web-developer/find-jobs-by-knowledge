using FindJobsByKnowledge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FindJobsByKnowledge.Repository.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Job> Jobs => Set<Job>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Company).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.Location).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Salary).HasColumnType("decimal(18,2)");
            entity.Property(e => e.RequiredKnowledge)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
        });
    }
}
