using SQLite;

namespace Contacts.Infrastructure.SqLiteRepository;
internal class SqLiteConnectionBuilder
{
    private readonly SqLiteConfigurations _configurations;

    public SqLiteConnectionBuilder(SqLiteConfigurations configurations)
    {
        _configurations = configurations;
    }

    public SQLiteConnection GetConnection()
    {
        var databaseName = _configurations.DbName;
        var folderPath = _configurations.FolderPath;
        var databasePath = System.IO.Path.Combine(folderPath, databaseName);

        return new SQLiteConnection(databasePath);
    }
}
