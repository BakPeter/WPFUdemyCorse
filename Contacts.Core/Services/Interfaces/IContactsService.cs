using Contacts.Core.Model;

namespace Contacts.Core.Services.Interfaces;

public interface IContactsService
{
    Task<SaveContactResultModel> SaveContact(ContactModel contactModel);
}