using CSharpFunctionalExtensions;

namespace skye_back.Domain.User;

public class User
{
    // EF Core
    private User() { }
    
    private User(YandexId yandexId, Email email, Name name, bool isActive)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        YandexId = yandexId;
        Email = email;
        Name = name;
        IsActive = isActive;
    }
    
    public Guid Id { get; private set; }

    public YandexId YandexId { get; private set; }

    public Email Email { get; private set; }

    public Name Name { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public static Result<User> Create(YandexId yandexId, Email email, Name name, bool isActive)
    {
        var obj = new User(yandexId, email, name, isActive);
        return Result.Success(obj);
    }
}