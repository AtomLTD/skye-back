using CSharpFunctionalExtensions;

namespace skye_back.Domain.Conversation;

public class Conversation
{
    // EF Core
    private Conversation() { }
    
    private Conversation(Guid userId, Title title, Model model)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        UserId = userId;
        Title = title;
        Model = model;
    }

    public Guid Id { get; private set; }

    public Guid UserId { get; private set; }

    public Title Title { get; private set; }

    public Model Model { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public static Result<Conversation> Create(Guid userId, Title title, Model model)
    {
        var obj = new Conversation(userId, title, model);
        return Result.Success(obj);
    }
}