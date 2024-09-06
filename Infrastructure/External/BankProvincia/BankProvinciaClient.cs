using System.Text.Json;
using test_codereview.Dto;
using test_codereview.Infrastructure.Contracts;
using test_codereview.Models;

namespace test_codereview.Infrastructure.External.BankProvincia;

public class BankProvinciaClient : IBankProvinciaClient
{
    private readonly BankProvinciaService bankProvinciaService;
    private readonly string CurrencyType = "USD";

    public BankProvinciaClient(BankProvinciaService bankProvinciaService)
    {
        this.bankProvinciaService = bankProvinciaService;
    }

    public async Task<ExchangeRateResponse> GetRate()
    {
        var response = await bankProvinciaService.GetRate();

        return new ExchangeRateResponse(response[0], response[1], CurrencyType);
    }

}
