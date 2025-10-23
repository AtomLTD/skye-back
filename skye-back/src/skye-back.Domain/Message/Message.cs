using CSharpFunctionalExtensions;

namespace skye_back.Domain.Message;

public class Message
{
    // EF Core
    private Message() { }

    private Message(Guid conversationId, Role role, Content content, Model model, int promptTokens, int completionTokens)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        ConversationId = conversationId;
        Role = role;
        Content = content;
        Model = model;
        PromptTokens = promptTokens;
        CompletionTokens = completionTokens;
    }

    public Guid Id { get; private set; }

    public Guid ConversationId { get; private set; }

    public Role Role { get; private set; }

    public Content Content { get; private set; }

    public Model Model { get; private set; }

    public int PromptTokens { get; private set; }

    public int CompletionTokens { get; private set; }
    
    public DateTime CreatedAt { get; private set; }

    public static Result<Message> Create(Guid conversationId, Role role, Content content, Model model, int promptTokens, int completionTokens)
    {
        var obj = new Message(conversationId, role, content, model, promptTokens, completionTokens);
        return Result.Success(obj);
    }
}