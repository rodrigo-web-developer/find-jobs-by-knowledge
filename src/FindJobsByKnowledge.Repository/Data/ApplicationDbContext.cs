using FindJobsByKnowledge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace FindJobsByKnowledge.Repository.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Job> Jobs => Set<Job>();
    public DbSet<Question> Questions => Set<Question>();
    public DbSet<Questionary> Questionaries => Set<Questionary>();
    public DbSet<QuestionaryItem> QuestionaryItems => Set<QuestionaryItem>();
    public DbSet<TagResult> TagResults => Set<TagResult>();

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

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Tag).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Text).IsRequired().HasMaxLength(1000);
            entity.Property(e => e.Level).IsRequired();
            entity.Property(e => e.Options)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions?)null) ?? new List<string>())
                .HasColumnType("text");
            entity.HasIndex(e => new { e.Tag, e.Level });
        });

        modelBuilder.Entity<Questionary>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Tags)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions?)null) ?? new List<string>())
                .HasColumnType("text");
            entity.HasMany(e => e.Items).WithOne(i => i.Questionary).HasForeignKey(i => i.QuestionaryId).OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(e => e.Results).WithOne(r => r.Questionary).HasForeignKey(r => r.QuestionaryId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<QuestionaryItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Question).WithMany().HasForeignKey(e => e.QuestionId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<TagResult>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Tag).IsRequired().HasMaxLength(100);
            entity.Property(e => e.PercentagePerLevel)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<Dictionary<int, double>>(v, (JsonSerializerOptions?)null) ?? new Dictionary<int, double>())
                .HasColumnType("text");
        });
    }
}
