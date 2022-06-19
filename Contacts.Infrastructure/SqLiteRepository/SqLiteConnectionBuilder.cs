using Contacts.Infrastructure.SqLiteRepository.Entities;
using SQLite;

namespace Contacts.Infrastructure.SqLiteRepository;
public class SqLiteConnectionBuilder
{
    private readonly SqLiteConfigurations _configurations;

    public SqLiteConnectionBuilder(SqLiteConfigurations configurations)
    {
        _configurations = configurations;
    }

    public SQLiteConnection GetConnection<TEntity>()
    {
        var databaseName = _configurations.DbName;
        var folderPath = _configurations.FolderPath;
        var databasePath = System.IO.Path.Combine(folderPath, databaseName);

        var connection = new SQLiteConnection(databasePath);

        connection.CreateTable<ContactEntity>();

        return connection;
    }
}
