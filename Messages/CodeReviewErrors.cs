using test_codereview.Application.Models;

namespace test_codereview.Messages;

public static class CodeReviewErrors
{
    public static Error GenericError(string description) => new("Internal Error", description);

    public static readonly Error InvalidCurrency = new("Invalid.Currency", "Invalid Currency");

}
