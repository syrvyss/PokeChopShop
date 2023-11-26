using Data;
using Logic.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Logic;

public class Program
{
    private static void Main(string[] args)
    {
        // Set up dependency injection
        var serviceProvider = new ServiceCollection()
            .AddScoped<EfCoreContext>() // Add EfCoreContext to the DI container
            // Add other controllers and dependencies here
            .BuildServiceProvider();
    }
}