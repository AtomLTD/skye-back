using CSharpFunctionalExtensions;
using skye_back.Domain.UserConversations;

namespace skye_back.Domain.User;

public class User
{
    // EF Core
    private User() { }
    
    private User(YandexId yandexId, Email email, Name name, bool isActive, List<UserConversation>? userConversations)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        YandexId = yandexId;
        Email = email;
        Name = name;
        IsActive = isActive;
        _userConversations = userConversations;
    }
    
    public Guid Id { get; private set; }

    public YandexId YandexId { get; private set; }

    public Email Email { get; private set; }

    public Name Name { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    private readonly List<UserConversation>? _userConversations = [];

    public IReadOnlyList<UserConversation>? UserConversations => _userConversations;

    public static Result<User> Create(YandexId yandexId, Email email, Name name, bool isActive, List<UserConversation>? userConversations)
    {
        var obj = new User(yandexId, email, name, isActive, userConversations);
        return Result.Success(obj);
    }
}