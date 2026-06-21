using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataAccess.Data;

public class ProjectManagementContext : DbContext
{
    public ProjectManagementContext(DbContextOptions<ProjectManagementContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<TaskItem> Tasks => Set<TaskItem>();
    public DbSet<Status> Statuses => Set<Status>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(u => u.Name).HasMaxLength(100).IsRequired();
            entity.Property(u => u.Email).HasMaxLength(255).IsRequired();
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.Property(s => s.Name).HasMaxLength(50).IsRequired();
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.Property(p => p.Name).HasMaxLength(200).IsRequired();
            entity.Property(p => p.Description).HasMaxLength(1000);

            entity.HasOne(p => p.User)
                .WithMany(u => u.Projects)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.ToTable("TaskItems");

            entity.Property(t => t.Title).HasMaxLength(200).IsRequired();
            entity.Property(t => t.Description).HasMaxLength(1000);

            entity.HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(t => t.Status)
                .WithMany(s => s.Tasks)
                .HasForeignKey(t => t.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
