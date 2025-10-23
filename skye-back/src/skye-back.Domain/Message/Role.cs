using CSharpFunctionalExtensions;

namespace skye_back.Domain.Message;

public record Role
{
    private Role(string value)
    {
        Value = value;
    }
    
    public string Value { get; }

    private static readonly Role _user = new("user");
    private static readonly Role _assistant = new("assistant");
    private static readonly Role _system = new("system");
    
    private static readonly HashSet<string> _allowed =
        new(StringComparer.OrdinalIgnoreCase) { "user", "assistant", "system" };
    
    public static Result<Role> Create(string role)
    {
        if (string.IsNullOrWhiteSpace(role))
            return Result.Failure<Role>("Роль не может быть пустой!");

        string value = role.Trim().ToLowerInvariant();

        if (!_allowed.Contains(value))
            return Result.Failure<Role>($"Неверная роль: {role}. Допустимые: user, assistant, system.");
        
        return value switch
        {
            "user" => Result.Success(_user),
            "assistant" => Result.Success(_assistant),
            "system" => Result.Success(_system),
            _ => Result.Failure<Role>("Unexpected role.")
        };
    }
}