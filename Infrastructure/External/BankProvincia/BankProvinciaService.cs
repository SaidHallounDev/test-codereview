namespace test_codereview.Infrastructure.External.BankProvincia
{
    public sealed class BankProvinciaService
    {
        private readonly HttpClient httpClient;

        public BankProvinciaService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<string>?> GetRate()
        {
            var response = await httpClient.GetFromJsonAsync<List<string>>("Principal/Dolar");
            return response;
        }
    }
}
