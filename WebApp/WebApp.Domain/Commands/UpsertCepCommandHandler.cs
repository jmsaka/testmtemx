namespace WebApp.Domain.Commands;

public class UpsertCepCommand : IRequest<int>
{
    public string Cep { get; set; }
}

public class UpsertCepCommandHandler : IRequestHandler<UpsertCepCommand, int>
{
    private readonly ICepRepository _repository;
    private readonly IMapper _mapper;
    private readonly IViaCepServiceClient _viaCepServiceClient;

    public UpsertCepCommandHandler(ICepRepository repository, IMapper mapper, IViaCepServiceClient viaCepServiceClient)
    {
        _repository = repository;
        _mapper = mapper;
        _viaCepServiceClient = viaCepServiceClient;
    }

    public async Task<int> Handle(UpsertCepCommand request, CancellationToken cancellationToken)
    {
        var cepResponse = await _viaCepServiceClient.GetCepAsync(request.Cep);

        var entity = _mapper.Map<CepEntity>(cepResponse);
        await _repository.AddCepAsync(entity);
        return entity.Id;
    }
}