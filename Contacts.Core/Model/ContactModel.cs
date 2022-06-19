using System.Text.Json;

namespace Contacts.Core.Model;
public class ContactModel
{
    public int Id { get; set; } = -1;
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
