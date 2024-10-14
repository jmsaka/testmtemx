namespace WebApp.Domain.Queries;

public class GetCepByUfQuery : IRequest<List<CepEntity>>
{
    public string Uf { get; set; }
    public GetCepByUfQuery(string uf)
    {
        Uf = uf;
    }
}
public class GetCepByUfQueryHandler : IRequestHandler<GetCepByUfQuery, List<CepEntity>>
{
    private readonly ICepRepository _repository;

    public GetCepByUfQueryHandler(ICepRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CepEntity>> Handle(GetCepByUfQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetCepsByUfAsync(request.Uf);
    }
}
