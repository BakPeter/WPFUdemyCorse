using System.Windows;

namespace Calculator.App;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private int _counter = 0;
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        _counter++;
        var result = MessageBox.Show($"Count: {_counter}", "Counter Shower", MessageBoxButton.YesNoCancel, MessageBoxImage.Information);
    }
}