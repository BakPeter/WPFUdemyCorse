using System.Windows;
using Contacts.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using Contacts.App.Helpers;

namespace Contacts.App;

public partial class App : Application
{

    public App()
    {
        var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

        AppHost.Host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) => ConfigureServices(services, config))
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

    private void ConfigureServices(IServiceCollection services, IConfigurationRoot config)
    {
        services.AddSingleton<MainWindow>();
        services.AddSingleton(config);

        var dbSettingsSection = config.GetSection("DBSettings");
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
        await AppHost.Host.StartAsync();

        var mainWindow = AppHost.Host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        using (AppHost.Host)
        {
            await AppHost.Host.StopAsync();
        }
        base.OnExit(e);
    }
}