using Contacts.Core.Model;

namespace Contacts.Core.Repository.Contacts.Queries;
public interface IGetContactsQuery
{
    Task<GetContactsResultModel> GetContactsAsync();
}
    
