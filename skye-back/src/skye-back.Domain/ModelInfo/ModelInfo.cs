using CSharpFunctionalExtensions;

namespace skye_back.Domain.ModelInfo;

public class ModelInfo
{
    private const int MAX_LENGTH = 100;
    
    // EF Core
    private ModelInfo() { }
    
    private ModelInfo(Model model, string displayName, int contextWindow, PricePerThousand priceInputPer1K, PricePerThousand priceOutputPer1K, bool enabled)
    {
        Id = Guid.NewGuid();
        UpdatedAt = DateTime.UtcNow;
        Model = model;
        DisplayName = displayName;
        ContextWindow = contextWindow;
        PriceInputPer1K = priceInputPer1K;
        PriceOutputPer1K = priceOutputPer1K;
        Enabled = enabled;
    }

    public Guid Id { get; private set; }

    public Model Model { get; private set; }

    public string DisplayName { get; private set; }

    public int ContextWindow { get; private set; }
    
    public PricePerThousand? PriceInputPer1K { get; private set; }
    
    public PricePerThousand? PriceOutputPer1K { get; private set; }
    
    public bool Enabled { get; private set; }
    
    public DateTime UpdatedAt { get; private set; }

    public static Result<ModelInfo> Create(Model model, string displayName, int contextWindow, PricePerThousand priceInputPer1K, PricePerThousand priceOutputPer1K, bool enabled)
    {
        if (string.IsNullOrWhiteSpace(displayName))
            return Result.Failure<ModelInfo>("Отображаемое имя не должно быть пустым!");

        if (displayName.Length > MAX_LENGTH)
            return Result.Failure<ModelInfo>("Отображаемое имя превышает допустимый размер!");

        if (contextWindow <= 0)
            return Result.Failure<ModelInfo>("Неверный размер контекста");

        var obj = new ModelInfo(model, displayName, contextWindow, priceInputPer1K, priceOutputPer1K, enabled);
        return Result.Success(obj);
    }
}