using SQLite;

namespace Contacts.Infrastructure.SqLiteRepository.Entities;

[Table("Contacts")]
internal class ContactEntity
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
}