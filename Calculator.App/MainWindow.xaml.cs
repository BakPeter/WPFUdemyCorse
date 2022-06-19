using System;
using System.Net.WebSockets;
using System.Windows;
using System.Windows.Controls;
using Calculator.Core.Enums;
using Calculator.Core.Model;
using Calculator.Core.Services;
using Calculator.Core.Services.Interfaces;

namespace Calculator.App;

public partial class MainWindow : Window
{
    private string _lastNumber = "";
    private MathOperations _mathOperations = MathOperations.NotDefined;

    private readonly ICalculatorService _calculatorService;

    public MainWindow(ICalculatorService calculatorService)
    {
        InitializeComponent();
        _calculatorService = calculatorService;
    }
    private void Dig0Button_Click(object sender, RoutedEventArgs e)
    {
        DigitButtonClicked("0");
    }
    private void Dig1Button_Click(object sender, RoutedEventArgs e)
    {
        DigitButtonClicked("1");
    }
    private void Dig2Button_Click(object sender, RoutedEventArgs e)
    {
        DigitButtonClicked("2");
    }
    private void Dig3Button_Click(object sender, RoutedEventArgs e)
    {
        DigitButtonClicked("3");
    }
    private void Dig4Button_Click(object sender, RoutedEventArgs e)
    {
        DigitButtonClicked("4");
    }
    private void Dig5Button_Click(object sender, RoutedEventArgs e)
    {
        DigitButtonClicked("5");
    }
    private void Dig6Button_Click(object sender, RoutedEventArgs e)
    {
        DigitButtonClicked("6");
    }
    private void Dig7Button_Click(object sender, RoutedEventArgs e)
    {
        DigitButtonClicked("7");
    }
    private void Dig8Button_Click(object sender, RoutedEventArgs e)
    {
        DigitButtonClicked("8");
    }
    private void Dig9Button_Click(object sender, RoutedEventArgs e)
    {
        DigitButtonClicked("9");
    }
    private void DigitButtonClicked(string digit)
    {
        var numberStr = ResultLabel.Content.ToString();
        numberStr = numberStr is "0" ? digit : $"{numberStr}{digit}";

        ResultLabel.Content = numberStr;
    }

    private void DotButton_Click(object sender, RoutedEventArgs e)
    {
        var numberStr = ResultLabel.Content.ToString();
        if (numberStr != null && numberStr.Contains('.')) return;
        ResultLabel.Content = $"{numberStr}.";
    }

    private void ACButton_Click(object sender, RoutedEventArgs e)
    {
        _lastNumber = "";
        ResultLabel.Content = "0";
        _mathOperations = MathOperations.NotDefined;
    }

    private void NegativeButton_Click(object sender, RoutedEventArgs e)
    {
        var numberStr = ResultLabel.Content.ToString();

        if (numberStr is "")
            numberStr = "0";

        numberStr = numberStr != null && numberStr.Contains('-')
            ? numberStr.Remove(0, 1)
            : $"-{numberStr}";

        ResultLabel.Content = numberStr;
    }

    private void OperationButton_Click(object sender, RoutedEventArgs e)
    {
        if (_mathOperations is MathOperations.NotDefined)
        {
            _mathOperations = GetMathOperation(sender);
            _lastNumber = ResultLabel.Content.ToString() ?? string.Empty;
            ResultLabel.Content = "0";
        }
        else
        {
            SendCalculationRequestToService();
        }
    }

    private void SendCalculationRequestToService()
    {
        try
        {
            var value1 = double.Parse(_lastNumber);
            var value2 = double.Parse(ResultLabel.Content.ToString() ?? string.Empty);
            var result = _calculatorService.Calculate(new CalculateOperationModel(value1, value2, _mathOperations));
            if (result.Success is false)
            {
                ShowError(result.ErrorMessage);
            }

            InitMembers();
            ResultLabel.Content = result.Result;
        }
        catch (Exception e)
        {
            ShowError(e.Message);
        }
    }

    private void ShowError(string error)
    {
        MessageBox.Show(error, "Error Occurred", MessageBoxButton.OK, MessageBoxImage.Error);
        InitMembers();
    }

    private void InitMembers()
    {
        _lastNumber = string.Empty;
        ResultLabel.Content = "0";
        _mathOperations = MathOperations.NotDefined;
    }

    private MathOperations GetMathOperation(object sender)
    {
        if (sender is not Button button) return MathOperations.NotDefined;

        return button.Name switch
        {
            "AdditionButton" => MathOperations.Add,
            "SubtractionButton" => MathOperations.Subtract,
            "MultiplierButton" => MathOperations.Multiply,
            "DivisionButton" => MathOperations.Divide,
            "PercentageButton" => MathOperations.Percentage,
            _ => MathOperations.NotDefined
        };
    }

    private void EqualsButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            if (_mathOperations is MathOperations.NotDefined)
                throw new ArgumentException($"Math operation is {_mathOperations}");
            if (_lastNumber.Equals(""))
                throw new ArgumentException($"Value1 is {_lastNumber}");

            SendCalculationRequestToService();
        }
        catch (Exception exception)
        {
            ShowError(exception.Message);
        }
    }
}