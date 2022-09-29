using Microsoft.EntityFrameworkCore;

namespace Assignment3.Entities;

public sealed class KanbanContext : DbContext
{
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<Task> Tasks => Set<Task>();
    public DbSet<User> Users => Set<User>();

    public KanbanContext(DbContextOptions<KanbanContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}