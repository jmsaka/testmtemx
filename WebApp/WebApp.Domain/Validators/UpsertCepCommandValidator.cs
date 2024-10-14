namespace WebApp.Domain.Validators;

public class UpsertCepCommandValidator : AbstractValidator<UpsertCepCommand>
{
    public UpsertCepCommandValidator()
    {
        RuleFor(x => x.Cep)
            .NotEmpty().WithMessage("CEP é obrigatório")
            .Length(8).WithMessage("CEP deve conter 8 caracteres");
    }
}
