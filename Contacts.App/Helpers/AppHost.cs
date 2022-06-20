using Microsoft.Extensions.Hosting;
using System;

namespace Contacts.App.Helpers;
public class AppHost
{
    private static IHost _host = null!;
    public static IHost Host
    {
        get => _host is null ? throw new ArgumentNullException("Host is null") : _host;
        set => _host = value;
    }
}
