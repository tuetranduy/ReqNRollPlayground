using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reqnroll.Microsoft.Extensions.DependencyInjection;
using ReqnRollPlayground.Context;
using ReqnRollPlayground.Services;

public class TestDependenciesResolver
{
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();

        var services = new ServiceCollection();
    
        services.AddSingleton<IConfiguration>(configuration);
        services.AddScoped<CalculatorContext>();
        services.AddScoped<MailService>();

        return services;
    }
}