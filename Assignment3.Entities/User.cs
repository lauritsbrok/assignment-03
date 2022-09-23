namespace Assignment3.Entities;

public class User
{
    public int Id { get; init; }

    [Required, MaxLength(100)]
    public string Name { get; set; }
    
    [Required, EmailAddress, Key]
    public string Email { get; set; }

    public List<Task> Tasks {get; set;}
}