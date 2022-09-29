using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Assignment3.Entities.Tests;

public class TaskRepositoryTests
{
    public TaskRepositoryTests()
    {
        var connection = new SqliteConnection("Filename=:memory:");
        connection.Open();
        var builder = new DbContextOptionsBuilder<KanbanContext>();
        builder.UseSqlite(connection);
        var context = new KanbanContext(builder.Options);
        context.Database.EnsureCreated();
        context.Tasks.AddRange(new Task{Id = 0, Title ="gaew", AssignedTo = new User{Name = "a", Email = "a@gmail.com", Tasks = new List<Task>()}, Description = "aeha g", State = State.New, Tags = new List<Tag>(), Created = DateTime.Now, Updated = DateTime.Now});
        context.SaveChanges();

        _context = context;
        _repository = new TaskRepository(_context);
    }
    private readonly KanbanContext _context;
    private readonly TaskRepository _repository;
    /*[Fact]
    public void Create_given_Task_returns_Created_with_Task()
    {
        var (response, created) = _repository.Create(new TaskCreateDTO("test 3", 0, "test description 3", new List<string>()));

        response.Should().Be(Response.Created);

        created.Should().Be(1);
    }*/

    public void Dispose()
    {
        _context.Dispose();
    }
}
