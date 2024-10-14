namespace WebApp.Infrastructure.Repositories;

public class CepRepository : ICepRepository
{
    private readonly ApplicationDbContext _context;

    public CepRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddCepAsync(CepEntity cep)
    {
        _context.Ceps.Add(cep);
        await _context.SaveChangesAsync();
    }

    public async Task<List<CepEntity>> GetCepsByUfAsync(string uf)
    {
        return await _context.Ceps.Where(c => c.Uf == uf).ToListAsync();
    }
}
