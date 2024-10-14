namespace WebApp.Domain.Interfaces;

public interface IViaCepServiceClient
{
    Task<CepResponse> GetCepAsync(string cep);
}
