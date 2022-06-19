using System.Windows;
using Calculator.Core.Commands.Interfaces;
using Calculator.Core.Services;
using Calculator.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Calculator.App;

public partial class App : Application
{
    private readonly IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                ConfigureService(services);
            })
            .Build();
    }

    private void ConfigureService(IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        services.AddTransient<ICalculatorService, CalculatorService>();
        services.AddTransient<IAddCommand, AddCommand>();
    }
    protected override async void OnStartup(StartupEventArgs e)
    {
        await _host.StartAsync();

        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        using (_host)
        {
            await _host.StopAsync();
        }
        base.OnExit(e);
    }
}