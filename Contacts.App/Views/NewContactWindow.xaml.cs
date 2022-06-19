using System.Threading.Tasks;
using System.Windows;
using Contacts.Core.Model;
using Contacts.Core.Services.Interfaces;

namespace Contacts.App.Views;

public partial class NewContactWindow : Window
{
    private readonly IContactsService _contactsService;

    public NewContactWindow(IContactsService contactsService)
    {

        InitializeComponent();
        _contactsService = contactsService;

        ReadDataBaseAsync();
    }

    private async void ReadDataBaseAsync()
    {
        GetContactsResultModel result = await _contactsService.GetContactsAsync();
    }


    private async void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        var result = await _contactsService.SaveContactAsync(new Core.Model.ContactModel()
        {
            Name = NameTextBox.Text,
            Email = EmailTextBox.Text,
            Phone = PhoneNumberTextBox.Text
        });

        if (result.Success is true)
            MessageBox.Show("Contact Added!", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
        else
            MessageBox.Show($"Contact NOT Added!\n{result.ErrorMessage}", "Result", MessageBoxButton.OK, MessageBoxImage.Error);

        Close();
    }
}