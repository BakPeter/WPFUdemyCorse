using Contacts.Core.Model;

namespace Contacts.Core.Repository;

public interface IContactsRepository
{
    Task<SaveContactResultModel> SaveContactAsync(ContactModel contactModel);
    Task<GetContactsResultModel> GetContactsAsync();
}