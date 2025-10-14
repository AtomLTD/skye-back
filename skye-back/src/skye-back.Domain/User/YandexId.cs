using CSharpFunctionalExtensions;

namespace skye_back.Domain.User;

public record YandexId
{
    private YandexId(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<YandexId> Create(string yandexId)
    {
        var obj = new YandexId(yandexId);
        return Result.Success(obj);
    }
}