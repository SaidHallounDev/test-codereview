using Dapper;
using test_codereview.Application.Models;
using test_codereview.Dto;
using test_codereview.Infrastructure.Contracts;
using test_codereview.Infrastructure.Persistence;
using test_codereview.Messages;
using test_codereview.Models;

namespace test_codereview.Services;

public class RateService : IRateService
{
    private readonly IBankProvinciaClient bancoProvinciaClient;

    public RateService(IBankProvinciaClient bancoProvinciaClient)
    {
        this.bancoProvinciaClient = bancoProvinciaClient;
    }

    public async Task<Result<ExchangeRateResponse>> GetCurrencyRate(CurrencyTypes currency)
    {
        switch (currency)
        {
            case CurrencyTypes.USD:
                return await this.GetRateFromExternalBankProvincia();
            case CurrencyTypes.REAL:
                return this.GetRateFromLocalSource();
            default:
                return Result<ExchangeRateResponse>.Failure(CodeReviewErrors.InvalidCurrency);
        }
    }

    private async Task<Result<ExchangeRateResponse>> GetRateFromExternalBankProvincia()
    {
        var rate = await this.bancoProvinciaClient.GetRate();
        return Result<ExchangeRateResponse>.Success(rate);
    }

    private Result<ExchangeRateResponse> GetRateFromLocalSource()
    {
        // TODO: ver si este dbContext deberia ir en otra capa/carpeta (ver ConfigManagerAPi) ademas ver como se inyecta para no instanciarlo
        var dbContext = new DatabaseContext();

        // TODO: Mover la sql query a otro lado, que nosea visible desde aqui.
        var exchangeRatesResponse = dbContext.GetConnection().Query<ExchangeRateResponse>("SELECT [Currency], [Buy], [Sell] FROM Cotizaciones2 WHERE [Currency] = 'Real'");
        var exchangeRateResponse = exchangeRatesResponse.LastOrDefault();

        return Result<ExchangeRateResponse>.Success(exchangeRateResponse);
    }
}
