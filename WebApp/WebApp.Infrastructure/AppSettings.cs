namespace WebApp.Infrastructure;

public class AppSettings
{
    public ApiServiceClient ApiSettings { get; set; }

    public DbConnection DbSettings { get; set; }

}

public class ApiServiceClient
{
    public string BaseUrlViaCep { get; set; }
}

public class DbConnection
{
    public string DefaultConnection { get; set; }
}