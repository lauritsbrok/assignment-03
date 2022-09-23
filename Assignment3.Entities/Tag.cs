using System.ComponentModel.DataAnnotations;

namespace Assignment3.Entities;

public class Tag
{
    public int Id {get; set;}
    [Required, MaxLength(50), Key]
    public string Name {get; set;} = default!;
    public virtual ICollection<Task> Tasks {get; set;} = default!;
}   
