using Contacts.Core.Model;

namespace Contacts.Core.Repository.Contacts.Commands;

public interface ISaveContactCommand
{
    Task<SaveContactResultModel> SaveContactAsync(ContactModel contactModel);
}