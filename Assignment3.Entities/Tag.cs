using Microsoft.EntityFrameworkCore;

namespace Assignment3.Entities;

[Index(nameof(Name), IsUnique = true)]
public class Tag
{
    public int Id {get; set;}
    [Required, MaxLength(50)]
    public string Name {get; set;} = default!;
    public virtual ICollection<Task> Tasks {get; set;} = default!;

    public Tag(string name) {
        Name = name;
        Tasks = new HashSet<Task>();
    }
}   
