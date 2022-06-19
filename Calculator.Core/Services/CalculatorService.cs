using Calculator.Core.Commands.Interfaces;
using Calculator.Core.Enums;
using Calculator.Core.Model;
using Calculator.Core.Services.Interfaces;

namespace Calculator.Core.Services;

public class CalculatorService : ICalculatorService
{
    private readonly IAddCommand _addCommand;
    private readonly ISubtractCommand _subtractCommand;

    public CalculatorService(
        IAddCommand addCommand,
        ISubtractCommand subtractCommand)
    {
        _addCommand = addCommand;
        _subtractCommand = subtractCommand;
        //_addCommand = new AddCommand();
    }

    public ResultModel Calculate(CalculateOperationModel calculateOperationModel)
    {
        return calculateOperationModel.MathOperations switch
        {
            MathOperations.Add => _addCommand.Add(calculateOperationModel.Value1, calculateOperationModel.Value2),
            MathOperations.Subtract => _subtractCommand.Subtract(calculateOperationModel.Value1, calculateOperationModel.Value2),
            _ => new ResultModel(Success: false, ErrorMessage: "Math Operation not implemented")
        };
    }
}