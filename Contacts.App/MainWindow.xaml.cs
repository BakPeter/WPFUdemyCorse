using System;
using System.Windows;
using Contacts.App.Views;
using Contacts.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Contacts.App;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
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