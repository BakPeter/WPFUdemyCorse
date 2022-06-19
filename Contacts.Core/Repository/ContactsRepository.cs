using Contacts.Core.Model;
using Contacts.Core.Repository.Contacts.Commands;
using Contacts.Core.Repository.Contacts.Queries;

namespace Contacts.Core.Repository;

public class ContactsRepository : IContactsRepository
{
    private readonly ISaveContactCommand _saveContactCommand;
    private readonly IGetContactsQuery _getContactsQuery;

    public ContactsRepository(
        ISaveContactCommand saveContactCommand,
        IGetContactsQuery getContactsQuery)
    {
        _saveContactCommand = saveContactCommand;
        _getContactsQuery = getContactsQuery;
    }

    public async Task<GetContactsResultModel> GetContactsAsync()
        => await _getContactsQuery.GetContactsAsync();

    public async Task<SaveContactResultModel> SaveContactAsync(ContactModel contactModel)
        => await _saveContactCommand.SaveContactAsync(contactModel);
}