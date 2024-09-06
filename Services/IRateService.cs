using test_codereview.Application.Infrastructure;
using test_codereview.Application.Models;
using test_codereview.Dto;
using test_codereview.Models;

namespace test_codereview.Services;

public interface IRateService
{
    Task<Result<ExchangeRateResponse>> GetCurrencyRate(CurrencyTypes currency);
}
