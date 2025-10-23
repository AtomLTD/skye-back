using CSharpFunctionalExtensions;

namespace skye_back.Domain.Message;

public record Content
{
    private const int MAX_LENGTH = 20 * 1000;
        
    private Content(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<Content> Create(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            return Result.Failure<Content>("Контент не может быть пустым!");

        if (content.Length > MAX_LENGTH)
            return Result.Failure<Content>("Контент превышает допустимое число символов!");

        var obj = new Content(content);
        return Result.Success(obj);
    }
}