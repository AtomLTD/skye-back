using CSharpFunctionalExtensions;

namespace skye_back.Domain.UserPreference;

public class UserPreference
{
    // EF Core
    private UserPreference() { }
    
    private UserPreference(Guid userId, Model defaultModel, Theme theme, bool streamByDefault, string streamPromptDefault)
    {
        UserId = userId;
        DefaultModel = defaultModel;
        Theme = theme;
        StreamByDefault = streamByDefault;
        StreamPromptDefault = streamPromptDefault;
    }

    public Guid UserId { get; private set; }

    public Model DefaultModel { get; private set; }

    public Theme Theme { get; private set; }

    public bool StreamByDefault { get; private set; }

    public string StreamPromptDefault { get; private set; }

    public static Result<UserPreference> Create(Guid userId, Model defaultModel, Theme theme, bool streamByDefault, string streamPromptDefault)
    {
        var obj = new UserPreference(userId, defaultModel, theme, streamByDefault, streamPromptDefault);
        return Result.Success(obj);
    }
}