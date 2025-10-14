using CSharpFunctionalExtensions;

namespace skye_back.Domain.User;

public class User
{
    // EF Core
    private User() { }
    private User(string yandexId, Email email, Name name, bool isActive)
    {
        Id = Guid.NewGuid();
    }
    
    public Guid Id { get; private set; }

    public string YandexId { get; private set; }

    public Email Email { get; private set; }

    public Name Name { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public static Result<User> Create()
    {
        
    }
}