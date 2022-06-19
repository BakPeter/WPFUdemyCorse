using Contacts.Core.Model;

namespace Contacts.Core.Services.Interfaces;

public interface IContactsService
{
    Task<SaveContactResultModel> SaveContactAsync(ContactModel contactModel);
    Task<GetContactsResultModel> GetContactsAsync();
}