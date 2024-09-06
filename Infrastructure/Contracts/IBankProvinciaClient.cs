namespace test_codereview.Infrastructure.Contracts;

using test_codereview.Dto;
using test_codereview.Models;

public interface IBankProvinciaClient
{
    Task<ExchangeRateResponse> GetRate();
}
