using CSharpFunctionalExtensions;

namespace skye_back.Domain.UserConversations;

public class UserConversation
{
    // EF Core
    private UserConversation() { }

    private UserConversation(Guid userId, Guid conversationId)
    {
        UserId = userId;
        ConversationId = conversationId;
    }

    public Guid UserId { get; private set; }

    public Guid ConversationId { get; private set; }

    public static Result<UserConversation> Create(Guid userId, Guid conversationId)
    {
        var obj = new UserConversation(userId, conversationId);
        return Result.Success(obj);
    }
}