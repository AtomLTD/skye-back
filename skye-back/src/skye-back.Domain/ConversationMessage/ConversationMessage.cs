using CSharpFunctionalExtensions;

namespace skye_back.Domain.ConversationMessages;

public class ConversationMessage
{
    // EF Core
    private ConversationMessage() { }

    private ConversationMessage(Guid conversationId, Guid messageId)
    {
        ConversationId = conversationId;
        MessageId = messageId;
    }

    public Guid ConversationId { get; private set; }

    public Guid MessageId { get; private set; }

    public static Result<ConversationMessage> Create(Guid conversationId, Guid messageId)
    {
        var obj = new ConversationMessage(conversationId, messageId);
        return Result.Success(obj);
    }
}