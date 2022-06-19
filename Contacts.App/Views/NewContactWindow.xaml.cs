using System;
using System.Windows;
using SQLite;

namespace Contacts.App.Views;

public partial class NewContactWindow : Window
{
    public NewContactWindow()
    {
        InitializeComponent();
    }

    private void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        var contact = new Contact()
        {
            Name = NameTextBox.Text,
            Email = EmailTextBox.Text,
            Phone = PhoneNumberTextBox.Text
        };

        var databaseName = "Contacts.db";
        var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var databasePath = System.IO.Path.Combine(folderPath, databaseName);

        using (var connection = new SQLiteConnection(databasePath))
        {
            connection.CreateTable<Contact>();
            connection.Insert(contact);
        }

        Close();
    }
}