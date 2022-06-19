using System.Windows;
using Contacts.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;

namespace Contacts.App;

public partial class App : Application
{
    public static IConfiguration? Config { get; private set; }

    private static IHost? _host;
    public static IHost? AppHost => _host;

    public App()
    {
        Config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) => ConfigureServices(services))
            .Build();

        //try
        //{
        //    Config = new ConfigurationBuilder()
        //        .AddJsonFile("appsettings.json")
        //        .Build();
        //    var settings = Config.Get<Contacts.App.Settings>();

        //    var settingsA = Config.GetValue(typeof(string), "SettingsA");

        //    var settingsB = Config.GetSection("SettingsB");
        //    var B_A = settingsB["B_A"];
        //    var B_B = settingsB["B_B"];
        //    var B_C = settingsB["B_C"];

        //    var settingsCB = Config.GetSection("SettingsC").Get<string[]>();
        //}
        //catch (System.Exception)
        //{
        //    //set default valus for settings
        //    throw;
        //}
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();

        var dbSettingsSection = Config!.GetSection("DBSettings");

        var folderPath = dbSettingsSection["FolderPath"];
        if (folderPath.Equals(""))
            folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        var settings = new Contacts.Core.Configurations.Settings
        {
            DbName = dbSettingsSection["DbName"],
            FolderPath = folderPath
        };
        services.AddContactsServices(settings);
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await _host!.StartAsync();

        //var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        //mainWindow.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        using (_host)
        {
            await _host!.StopAsync();
        }
        base.OnExit(e);
    }
}