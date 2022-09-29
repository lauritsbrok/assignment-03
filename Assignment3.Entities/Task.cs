using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment3.Entities;

public class Task
{
    public int Id { get; init; }
    [Required, MaxLength(100)]
    public string Title { get; set; } = default!;
    public User AssignedTo {get; set;} = default!;
    public string Description { get; set; } = default!;
    [Column(TypeName = "nvarchar(24)")]
    public State State {get; set;}
    public virtual ICollection<Tag> Tags { get; set;} = default!;
    public DateTime Created { get; set;}
    public DateTime Updated { get; set;}
}
