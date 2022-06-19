using Contacts.Core.Model;
using Contacts.Core.Repository;
using Contacts.Core.Services.Interfaces;

namespace Contacts.Core.Services;
public class ContactsService : IContactsService
{
    private readonly IContactsRepository _contactsRepository;

    public ContactsService(IContactsRepository contactsRepository)
    {
        _contactsRepository = contactsRepository;
    }

    public Task<SaveContactResultModel> SaveContact(ContactModel contactModel)
        => _contactsRepository.SaveContact(contactModel);
}
