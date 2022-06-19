using Contacts.Core.Services;
using Contacts.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Contacts.Infrastructure;

public static class ServicesCollectionExtension
{
    public static void AddContactsServices(this IServiceCollection services)
    {
        services.AddSingleton<IContactsService, ContactsService>();
    }
}