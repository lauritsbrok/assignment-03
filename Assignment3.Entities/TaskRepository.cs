using Microsoft.EntityFrameworkCore;

namespace Assignment3.Entities;

public sealed class TaskRepository : ITaskRepository
{
    private readonly KanbanContext _context;

    public TaskRepository(KanbanContext context)
        {
            _context = context;
        }

    public (Response Response, int TaskId) Create(TaskCreateDTO task)
    {
        var entity = _context.Tasks.FirstOrDefault(c => c.Title == task.Title);
        Response response;

        if (entity is null)
        {
            var now = DateTime.Now;
            ICollection<Tag> tags = new List<Tag>();
            foreach (var t in task.Tags) {
                tags.Add(new Tag(t));
            }
            entity = new Task{Title = task.Title, Description = task.Description!, Tags = tags};

            _context.Tasks.Add(entity);
            _context.SaveChanges();

            response = Response.Created;
        }
        else
        {
            response = Response.Conflict;
        }

        var created = new TagDTO(entity.Id, entity.Title);

        return (response, created.Id);
    }

    public Response Delete(int taskId)
    {
        var task = _context.Tasks.Include(t => t.Id).FirstOrDefault(t => t.Id == taskId);
        Response response;

        if (task is null)
        {
            response = Response.NotFound;
        }
        else if (task.Tags.Any())
        {
            response = Response.Conflict;
        }
        else 
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();

            response = Response.Deleted;
        }

        return response;
    }

    public TaskDetailsDTO Read(int taskId)
    {
        var task = from t in _context.Tasks
                    where t.Id == taskId
                     select new TaskDetailsDTO (t.Id, t.Title, t.Description, t.Created, t.AssignedTo.Name,(IReadOnlyCollection<string>) t.Tags, t.State, t.Updated);
        return (TaskDetailsDTO) task;
    }

    public IReadOnlyCollection<TaskDTO> ReadAll()
    {
        var tasks = from t in _context.Tasks
                    select new TaskDTO (t.Id, t.Title, t.AssignedTo.Name, (IReadOnlyCollection<string>) t.Tags, t.State);
        return (IReadOnlyCollection<TaskDTO>) tasks;
    }

    public IReadOnlyCollection<TaskDTO> ReadAllByState(Core.State state)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyCollection<TaskDTO> ReadAllByTag(string tag)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyCollection<TaskDTO> ReadAllByUser(int userId)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyCollection<TaskDTO> ReadAllRemoved()
    {
        throw new NotImplementedException();
    }

    public Response Update(TaskUpdateDTO task)
    {
        throw new NotImplementedException();
    }
}
