namespace Contacts.Core.Model;
public record GetContactsResultModel(bool Success, List<ContactModel>? Result = null, string ErrorMessage = "");
