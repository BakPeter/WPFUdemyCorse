using Contacts.Core.Model;
using Contacts.Core.Repository.Contacts.Queries;
using Contacts.Infrastructure.SqLiteRepository.Entities;

namespace Contacts.Infrastructure.SqLiteRepository.Contacts.Queries;
public class SqliteGetContactsQuery : IGetContactsQuery
{
    private readonly SqLiteConnectionBuilder _connectionBuilder;

    public SqliteGetContactsQuery(SqLiteConnectionBuilder connectionBuilder)
    {
        _connectionBuilder = connectionBuilder;
    }

    public async Task<GetContactsResultModel> GetContactsAsync()
    {
        return await Task.Factory.StartNew(() =>
        {
            try
            {
                using var connection = _connectionBuilder.GetConnection<ContactEntity>();
                var contacts = connection.Table<ContactEntity>().ToList();

                var result = new List<ContactModel>();
                contacts.ForEach(contact =>
                {
                    result.Add(new ContactModel
                    {
                        Id = contact.Id,
                        Name = contact.Name,
                        Email = contact.Email,
                        Phone = contact.Phone,
                    });
                });

                return new GetContactsResultModel(Success: true, Result: result);
            }
            catch (Exception ex)
            {
                return new GetContactsResultModel(Success:false, ErrorMessage: ex.Message);
            }
           
        });
    }
}
