using CSharpFunctionalExtensions;

namespace skye_back.Domain.User;

public record Email
{
    private Email(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<Email> Create(string email)
    {
        var obj = new Email(email);
        return Result.Success(obj);
    }
}