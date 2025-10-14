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
        
        var obj = new Model(model);
        return Result.Success(obj);
    }
}