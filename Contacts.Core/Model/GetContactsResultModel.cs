namespace Contacts.Core.Model;
public record GetContactsResultModel(bool Success, List<ContactModel>? Contacts = null, string ErrorMessage = "");
