using Contacts.Core.Model;
using Contacts.Core.Repository.Contacts.Commands;
using Contacts.Infrastructure.SqLiteRepository.Entities;

namespace Contacts.Infrastructure.SqLiteRepository.Contacts.Commands;
public class SqliteSaveContactCommand : ISaveContactCommand
{
    private readonly SqLiteConnectionBuilder _connectionBuilder;

    public SqliteSaveContactCommand(SqLiteConnectionBuilder connectionBuilder)
    {
        _connectionBuilder = connectionBuilder;
    }

    public async Task<SaveContactResultModel> SaveContactAsync(ContactModel contactModel)
    {
        return await Task<SaveContactResultModel>.Factory.StartNew(() =>
        {
            try
            {
                using var connection = _connectionBuilder.GetConnection<ContactEntity>();
                var contactEntity = new ContactEntity
                {
                    Name = contactModel.Name,
                    Email = contactModel.Email,
                    Phone = contactModel.Phone,
                };

                var isertionResult = connection.Insert(contactEntity);

                if (isertionResult == 0)
                    return new SaveContactResultModel(Success: false, ErrorMessage: "Contacts insertion to DB failed");

                return new SaveContactResultModel(Success: true);
            }
            catch (Exception e)
            {
                return new SaveContactResultModel(Success: false, ErrorMessage: e.Message);
            }
        });
    }
}
