using CSharpFunctionalExtensions;

namespace skye_back.Domain.UserPreference;

public record Theme
{
    private Theme(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    private static readonly Theme _light = new("light");
    private static readonly Theme _dark = new("dark");
    
    private static readonly HashSet<string> _allowed =
        new(StringComparer.OrdinalIgnoreCase) { "light", "dark" };
    
    public static Result<Theme> Create(string theme)
    {
        if (string.IsNullOrWhiteSpace(theme))
            return Result.Failure<Theme>("Тема не может быть пустой!");

        string normalized = theme.Trim().ToLowerInvariant();

        if (!_allowed.Contains(normalized))
            return Result.Failure<Theme>($"Неизвестная тема: {theme}. Доступные: light, dark.");

        return normalized switch
        {
            "light" => Result.Success(_light),
            "dark" => Result.Success(_dark),
            _ => Result.Failure<Theme>("Неизвестная тема.")
        };
    }
}