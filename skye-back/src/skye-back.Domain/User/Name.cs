using CSharpFunctionalExtensions;

namespace skye_back.Domain.User;

public record Name
{
    private Name(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<Name> Create(string name)
    {
        var obj = new Name(name);
        return Result.Success(obj);
    }
}