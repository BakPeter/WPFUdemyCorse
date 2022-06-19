using Contacts.Core.Model;
using Contacts.Core.Repository.Contacts.Commands;

namespace Contacts.Core.Repository;

public class ContactsRepository : IContactsRepository
{
    private readonly ISaveContactCommand _saveContactCommand;

    public ContactsRepository(ISaveContactCommand saveContactCommand)
    {
        _saveContactCommand = saveContactCommand;
    }

    public Task<SaveContactResultModel> SaveContact(ContactModel contactModel)
        => _saveContactCommand.SaveContactAsync(contactModel);
}