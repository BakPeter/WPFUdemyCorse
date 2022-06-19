using Calculator.Core.Commands.Interfaces;
using Calculator.Core.Enums;
using Calculator.Core.Model;
using Calculator.Core.Services.Interfaces;

namespace Calculator.Core.Services;

public class CalculatorService : ICalculatorService
{
    private readonly IAddCommand _addCommand;

    public CalculatorService(IAddCommand addCommand)
    {
        _addCommand = addCommand;
        //_addCommand = new AddCommand();
    }

    public ResultModel Calculate(CalculateOperationModel calculateOperationModel)
    {
        return calculateOperationModel.MathOperations switch
        {
            MathOperations.Add => _addCommand.Add(calculateOperationModel.Value1, calculateOperationModel.Value2),
            _ => new ResultModel(Success: false, ErrorMessage: "Math Operation not implemented")
        };
    }
}