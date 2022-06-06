using BCAW;
using BCAW.BusinessLayer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services
            .AddTransient<UserInteractionService>()
            .AddTransient<IUserService, UserService>()
            .AddTransient<IOfferService, OfferService>()

        //.AddTransient<ITransientOperation, DefaultOperation>()
        //.AddScoped<IScopedOperation, DefaultOperation>()
        //.AddSingleton<ISingletonOperation, DefaultOperation>()
        //.AddTransient<UserInteractionService>()
        )
    .Build();

ExemplifyScoping(host.Services);

await host.RunAsync();

static void ExemplifyScoping(IServiceProvider services)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;

    var userInteractionService = provider.GetRequiredService<UserInteractionService>();
    userInteractionService.Run();

}