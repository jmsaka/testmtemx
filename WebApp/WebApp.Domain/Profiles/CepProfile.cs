namespace WebApp.Domain.Profiles;

public class CepProfile : Profile
{
    public CepProfile()
    {
        CreateMap<UpsertCepCommand, CepEntity>();

        CreateMap<CepResponse, CepEntity>()
            .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Cep))
            .ForMember(dest => dest.Logradouro, opt => opt.MapFrom(src => src.Logradouro))
            .ForMember(dest => dest.Bairro, opt => opt.MapFrom(src => src.Bairro))
            .ForMember(dest => dest.Localidade, opt => opt.MapFrom(src => src.Localidade))
            .ForMember(dest => dest.Uf, opt => opt.MapFrom(src => src.Uf));
    }
}
