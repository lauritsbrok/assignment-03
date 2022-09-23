namespace Assignment3.Entities;

public class User
{
    public int Id { get; init; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = default!;
    
    [Required, EmailAddress, Key]
    public string Email { get; set; } = default!;

    public List<Task> Tasks {get; set;} = default!;
}