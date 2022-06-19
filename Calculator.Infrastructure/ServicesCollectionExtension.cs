using Calculator.Core.Commands;
using Calculator.Core.Commands.Interfaces;
using Calculator.Core.Services;
using Calculator.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Infrastructure;

public static class ServicesCollectionExtension
{
    public static void AddCalculatorServices(this IServiceCollection services)
    {
        services.AddSingleton<ICalculatorService, CalculatorService>();
        services.AddSingleton<IAddCommand, AddCommand>();
        services.AddSingleton<ISubtractCommand, SubtractCommand>();
    }
}