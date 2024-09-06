namespace test_codereview.Dto;

public record ExchangeRateResponse
{
    public string Buy { get; init; }

    public string Sell { get; init; }

    public string Currency { get; init; }

    public ExchangeRateResponse()
    {
    }

    public ExchangeRateResponse(string compra, string venta, string moneda)
    {
        Buy = compra;
        Sell = venta;
        Currency = moneda;
    }
}
