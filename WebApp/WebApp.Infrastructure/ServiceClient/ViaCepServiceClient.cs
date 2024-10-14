namespace WebApp.Infrastructure.ServiceClient;

public class ViaCepServiceClient : IViaCepServiceClient
{
    private readonly HttpClient _httpClient;

    public ViaCepServiceClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CepResponse> GetCepAsync(string cep)
    {
        try
        {
            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Erro ao buscar o CEP: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();
            content = CleanResponse(content);
            var cepResponse = JsonConvert.DeserializeObject<CepResponse>(content);

            if (cepResponse == null || string.IsNullOrEmpty(cepResponse.Cep))
            {
                throw new Exception("CEP inválido ou não encontrado.");
            }

            return cepResponse;
        }
        catch (Exception e)
        {
            throw new Exception($"Erro ao buscar o CEP: {e}");
        }

    }

    private string CleanResponse(string content)
    {
        content = Regex.Replace(content, @"[^\u0020-\u007E]+", string.Empty);

        byte[] bytes = System.Text.Encoding.Default.GetBytes(content);
        content = System.Text.Encoding.UTF8.GetString(bytes);

        return content;
    }
}
