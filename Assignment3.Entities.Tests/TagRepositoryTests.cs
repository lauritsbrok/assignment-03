using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Data.Sqlite;

namespace Assignment3.Entities.Tests;

public sealed class TagRepositoryTests : IDisposable
{
    private readonly KanbanContext _context;
    private readonly TagRepository _repository;
public TagRepositoryTests()
    {
        var connection = new SqliteConnection("Filename=:memory:");
        connection.Open();
        var builder = new DbContextOptionsBuilder<KanbanContext>();
        builder.UseSqlite(connection);
        var context = new KanbanContext(builder.Options);
        context.Database.EnsureCreated();
        context.Tags.AddRange(new Tag("Thing") { Id = 1 }, new Tag("Not A Thing") { Id = 2 });
        context.SaveChanges();

        _context = context;
        _repository = new TagRepository(_context);
    }

    [Fact]
    public void Create_given_Tag_returns_Created_with_Tag()
    {
        var (response, created) = _repository.Create(new TagCreateDTO("Coolest Tag Ever"));

        response.Should().Be(Response.Created);

        created.Should().Be(3);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
