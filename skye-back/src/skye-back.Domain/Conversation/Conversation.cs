using CSharpFunctionalExtensions;

namespace skye_back.Domain.Conversation;

public class Conversation
{
    // EF Core
    private Conversation() { }
    
    private Conversation(Title title, Model model)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        Title = title;
        Model = model;
    }

    public Guid Id { get; private set; }

    public Title Title { get; private set; }

    public Model Model { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }
    
    public static Result<Conversation> Create(Title title, Model model)
    {
        var obj = new Conversation(title, model);
        return Result.Success(obj);
    }
}