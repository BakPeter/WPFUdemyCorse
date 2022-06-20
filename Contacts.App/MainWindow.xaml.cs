using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Contacts.App.Helpers;
using Contacts.App.Views;
using Contacts.Core.Model;
using Contacts.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Contacts.App;

public partial class MainWindow : Window
{
    private readonly IContactsService _contactsService;

    private List<ContactModel> _contacts = null!;

    public MainWindow()
    {
        _contactsService = AppHost.Host.Services.GetRequiredService<IContactsService>();

        InitializeComponent();

        PopulateContactsListViewAsync();
    }

    private async void PopulateContactsListViewAsync()
    {
        var result = await _contactsService.GetContactsAsync();
        ContactsListView.ItemsSource = result.Contacts;
        _contacts = result.Contacts!;

        //if (result.Success && result.Contacts?.Count > 0)
        //    foreach (var contact in result.Contacts)
        //    {
        //        ContactsListView.Items.Add(new ListViewItem()
        //        {
        //            Content = contact.ToString(),
        //            Margin = new Thickness(0, 0, 0, 5),
        //            Padding = new Thickness(0, 0, 0, 3),
        //            BorderBrush = Brushes.Blue,
        //            Foreground = Brushes.Green,
        //            Background = Brushes.LightGray
        //        });
        //    }
        //else
        //    foreach (var text in new string[] { "No contacts in the DB" })
        //    {
        //        ContactsListView.Items.Add(new ListViewItem()
        //        {
        //            Content = text,
        //            BorderBrush = Brushes.Black,
        //            Background = Brushes.OrangeRed,
        //            Foreground = Brushes.Blue,                    
        //        });
        //    }
    }

    private void AddNewContactButton_OnClick(object sender, RoutedEventArgs e)
    {
        //var result = MessageBox.Show(
        //    "Add new contact button clicked, do you want to add new contact?",
        //    "Add new contact",
        //    MessageBoxButton.YesNo, MessageBoxImage.Question);
        //Trace.WriteLine(result);

        //if (result is MessageBoxResult.No) return;

        var newContactWindow = new NewContactWindow(
            AppHost.Host.Services.GetRequiredService<IContactsService>());
        newContactWindow.ShowDialog();
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        var textBox = sender as TextBox;
        var filteredData =
            _contacts.Where(contact => contact.Name.ToLower().Contains(textBox!.Text.ToLower()));
    }
}