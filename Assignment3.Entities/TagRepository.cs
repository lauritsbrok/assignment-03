namespace Assignment3.Entities;


public class TagRepository : ITagRepository
{
    private readonly KanbanContext _context;

    public (Response Response, int TagId) Create(TagCreateDTO tag)
    {
        var entity = _context.Tags.FirstOrDefault(c => c.Name == tag.Name);
        Response response;

        if (entity is null)
        {
            entity = new Tags(tag.Name);

            _context.Tags.Add(entity);
            _context.SaveChanges();

            response = Created;
        }
        else
        {
            response = Conflict;
        }

        var created = new TagCreateDTO(entity.Name);

        return (response, );

    }

    public Response Delete(int tagId, bool force = false)
    {
        var tag = _context.Tags.Include(t => t.Id).FirstOrDefault(t => t.Id == tagId);
        Response response;

        if (tag is null)
        {
            response = Response.NotFound;
        }
        else if (tag.Tasks.Any())
        {
            response = Response.Conflict;
        }
        else 
        {
            _context.Tags.Remove(tag);
            _context.SaveChanges();

            response = Response.Deleted;
        }

        return response;
    }

    public TagDTO Read(int tagId)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyCollection<TagDTO> ReadAll()
    {
        throw new NotImplementedException();
    }

    public Response Update(TagUpdateDTO tag)
    {
        throw new NotImplementedException();
    }
}
