namespace WebApp.Api.IoC;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddHttpClient<ViaCepServiceClient>(client =>
        {
            var baseUrl = builder.Configuration["ApiServiceClient:BaseUrlViaCep"];

            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new Exception("A URL base para o ViaCepServiceClient não está configurada.");
            }

            client.BaseAddress = new Uri(baseUrl);
        });

        builder.Services.AddScoped<ICepRepository, CepRepository>();
        builder.Services.AddMediatR(typeof(UpsertCepCommandHandler).Assembly);
        builder.Services.AddAutoMapper(typeof(CepProfile));
        builder.Services.AddValidatorsFromAssemblyContaining<UpsertCepCommandValidator>();

        builder.Services.AddHttpClient<IViaCepServiceClient, ViaCepServiceClient>()
            .SetHandlerLifetime(TimeSpan.FromMinutes(5))
            .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(600)))
            .AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

        return builder.Services;
    }
}
