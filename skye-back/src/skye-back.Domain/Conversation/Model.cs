using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace skye_back.Domain.Conversation;

public record Model
{
    private Model(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<Model> Create(string model)
    {
        if (string.IsNullOrWhiteSpace(model))
            return Result.Failure<Model>("Модель не может быть пустой!");

        string value = model.Trim();
        
        if (!Regex.IsMatch(value, @"^[a-z0-9\-]+(/[a-z0-9\-]+)+$", RegexOptions.IgnoreCase))
            return Result.Failure<Model>($"Неверный формат модели: {value}");
        
        var obj = new Model(model);
        return Result.Success(obj);
    }
}