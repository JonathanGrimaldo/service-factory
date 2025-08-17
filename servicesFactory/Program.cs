using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using servicesFactory.Services.Soap.Crcind;
using servicesFactory.Services.Soap.Crcind.Adapters;
using servicesFactory.Services.TemplateProvider;

class Program
{
    static async Task Main(string[] args)
    {
        // 'host' is created here. Its scope is limited to this method.
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<ITemplateProviderService, TemplateProviderService>();
                services.AddSingleton<IGetByNameAdapter, GetByNameAdapter>();

                //Services
                services.AddScoped<ICrcindService, CrcindService>();


                // HttpClientFactory, se encarga de la inyección de HttpClient.
                services.AddHttpClient<ICrcindService, CrcindService>();
            })
            .Build();

        // This works because we are inside the 'Main' method.
        // Se usa GetService<T> para obtener la instancia del servicio del contenedor.
        var crcindService = host.Services.GetService<ICrcindService>();

        var result = await crcindService.GetByName("john");
        Console.WriteLine(result);

        await host.RunAsync();
    }
}