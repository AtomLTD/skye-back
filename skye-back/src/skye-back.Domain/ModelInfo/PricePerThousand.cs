using CSharpFunctionalExtensions;

namespace skye_back.Domain.ModelInfo;

public record PricePerThousand
{
    private PricePerThousand(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }
    
    public decimal Amount { get; private set; }  
    public string Currency { get; private set; }

    public static Result<PricePerThousand> Create(decimal amount, string currency)
    {
        if (amount < 0) 
            return Result.Failure<PricePerThousand>("Цена не может быть отрицательной!");

        string cur = string.IsNullOrWhiteSpace(currency) ? "USD" : currency.Trim().ToUpperInvariant();
        
        if (cur.Length is < 3 or > 3) 
            return Result.Failure<PricePerThousand>("Валюта должна содержать 3 символа!");

        var obj = new PricePerThousand(decimal.Round(amount, 6), cur);
        return Result.Success(obj);
    }
}