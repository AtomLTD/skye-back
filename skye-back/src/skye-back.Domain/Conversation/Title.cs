using CSharpFunctionalExtensions;

namespace skye_back.Domain.Conversation;

public record Title
{
    public const int MIN_LENGTH = 1;

    public const int MAX_LENGTH = 30;
    
    private Title(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<Title> Create(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return Result.Failure<Title>("Title не может быть пустым!");

        if (title.Length < MIN_LENGTH || title.Length > MAX_LENGTH)
            return Result.Failure<Title>("Неверная длинна названия чата!");
        
        var obj = new Title(title);
        return Result.Success(obj);
    }
}