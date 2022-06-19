using Contacts.Core.Configurations;
using Contacts.Core.Repository;
using Contacts.Core.Repository.Contacts.Commands;
using Contacts.Core.Repository.Contacts.Queries;
using Contacts.Core.Services;
using Contacts.Core.Services.Interfaces;
using Contacts.Infrastructure.SqLiteRepository;
using Contacts.Infrastructure.SqLiteRepository.Contacts.Commands;
using Contacts.Infrastructure.SqLiteRepository.Contacts.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Contacts.Infrastructure;

public static class ServicesCollectionExtension
{
    public static void AddContactsServices(this IServiceCollection services, Settings settings)
    {
        services.AddSingleton(settings);

        services.AddSingleton<IContactsService, ContactsService>();
        services.AddSingleton<IContactsRepository, ContactsRepository>();

        services.AddSingleton<ISaveContactCommand, SqliteSaveContactCommand>();
        services.AddSingleton<IGetContactsQuery, SqliteGetContactsQuery>();
        services.AddSingleton(new SqLiteConfigurations()
        {
            DbName = settings.DbName,
            FolderPath = settings.FolderPath
        });
        services.AddSingleton<SqLiteConnectionBuilder>();
    }
}