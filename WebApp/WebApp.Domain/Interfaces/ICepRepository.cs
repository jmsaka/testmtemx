namespace WebApp.Domain.Interfaces;

public interface ICepRepository
{
    Task AddCepAsync(CepEntity cep);
    Task<List<CepEntity>> GetCepsByUfAsync(string uf);
}
