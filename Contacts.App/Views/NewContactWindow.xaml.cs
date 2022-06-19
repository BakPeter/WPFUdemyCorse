using System;
using System.Windows;
using Contacts.Core.Repository;
using Contacts.Core.Services.Interfaces;
using SQLite;

namespace Contacts.App.Views;

public partial class NewContactWindow : Window
{
    private readonly IContactsService _contactsService;

    public NewContactWindow(IContactsService contactsService)
    {

        InitializeComponent();
        _contactsService = contactsService;
    }

    private async void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        var result = await _contactsService.SaveContact(new Core.Model.ContactModel()
        {
            Name = NameTextBox.Text,
            Email = EmailTextBox.Text,
            Phone = PhoneNumberTextBox.Text
        });

        if (result.Success is true)
            MessageBox.Show("Contact Added!", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
        else
            MessageBox.Show($"Contact NOT Added!\n{result.ErrorMessage}", "Result", MessageBoxButton.OK, MessageBoxImage.Error);
        
        //var contact = new Contact()
        //{
        //    Name = NameTextBox.Text,
        //    Email = EmailTextBox.Text,
        //    Phone = PhoneNumberTextBox.Text
        //};

        //var databaseName = "Contacts.db";
        //var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //var databasePath = System.IO.Path.Combine(folderPath, databaseName);

        //using (var connection = new SQLiteConnection(databasePath))
        //{
        //    connection.CreateTable<Contact>();
        //    connection.Insert(contact);
        //}

        Close();
    }
}