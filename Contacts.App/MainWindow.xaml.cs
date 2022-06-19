using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Contacts.App.Views;
using Contacts.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Contacts.App;

public partial class MainWindow : Window
{
    private readonly IContactsService _contactsService;

    public MainWindow()
    {
        _contactsService = App.AppHost!.Services.GetRequiredService<IContactsService>();

        InitializeComponent();

        PopulateContactsListViewAsync();
    }

    private async void PopulateContactsListViewAsync()
    {
        var result = await _contactsService.GetContactsAsync();

        if (result.Success && result.Contacts?.Count > 0)
            foreach (var contact in result.Contacts)
            {
                ContactsListView.Items.Add(new ListViewItem()
                {
                    Content = contact.ToString(),
                    Margin = new Thickness(0, 0, 0, 5),
                    Padding = new Thickness(0, 0, 0, 3),
                    BorderBrush = Brushes.Blue,
                    Foreground = Brushes.Green,
                    Background = Brushes.LightGray
                });
            }
        //ContactsListView.ItemsSource = result.Contacts;
        else
            foreach (var text in new string[] { "No contacts in the DB" })
            {
                ContactsListView.Items.Add(new ListViewItem()
                {
                    Content = text,
                    BorderBrush = Brushes.Black,
                    Background = Brushes.OrangeRed,
                    Foreground = Brushes.Blue,                    
                });
            }
        //ContactsListView.ItemsSource = new string[] { "No contacts in the DB" };
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
            App.AppHost!.Services.GetRequiredService<IContactsService>());
        newContactWindow.ShowDialog();
    }
}