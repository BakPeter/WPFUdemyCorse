using Contacts.Core.Model;

namespace Contacts.Core.Repository;

public interface IContactsRepository
{
    Task<SaveContactResultModel> SaveContact(ContactModel contactModel);
}