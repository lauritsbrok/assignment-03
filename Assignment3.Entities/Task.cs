using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment3.Entities;

public class Task
{
    public int Id { get; init; }
    [Required, MaxLength(100)]
    public string Title { get; set; }
    public User User {get; set;}

    public string Description { get; set; }
    [Required]

    private String _State;

    [Column(TypeName = "nvarchar(24)")]
    public State State {get; set;}
    public Tag Tag {get; set;}

    public virtual ICollection<Tag> Tags { get; set; }
}

public enum State{
    New,
    Active,
    Resolved,
    Closed,
    Removed
}
