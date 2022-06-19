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

    public async Task<GetContactsResultModel> GetContactsAsync()
        => await _contactsRepository.GetContactsAsync();
    public async Task<SaveContactResultModel> SaveContactAsync(ContactModel contactModel)
        => await _contactsRepository.SaveContactAsync(contactModel);
}
