using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment3.Entities;

public class Task
{
    public int Id { get; init; }
    [Required, MaxLength(100)]
    public string Title { get; set; } = default!;
    public User User {get; set;} = default!;

    public string Description { get; set; } = default!;
    [Required]

    private String _State = default!; 

    [Column(TypeName = "nvarchar(24)")]
    public State State {get; set;}
    public Tag Tag {get; set;} = default!;

    public virtual ICollection<Tag> Tags { get; set; } = default!;
}

public enum State{
    New,
    Active,
    Resolved,
    Closed,
    Removed
}
