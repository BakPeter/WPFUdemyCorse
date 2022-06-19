using Calculator.Core.Commands.Interfaces;
using Calculator.Core.Enums;
using Calculator.Core.Model;
using Calculator.Core.Services.Interfaces;

namespace Calculator.Core.Services;

public class CalculatorService : ICalculatorService
{
    private readonly IAdditionCommand _additionCommand;

    public CalculatorService()
    {
        _additionCommand = new AdditionCommand();
    }

    public ResultModel Calculate(CalculateOperationModel calculateOperationModel)
    {
        return calculateOperationModel.MathOperations switch
        {
            MathOperations.Add => _additionCommand.Add(calculateOperationModel.Value1, calculateOperationModel.Value2);
            _ => new ResultModel(OperationSuccess: false, ErrorMessage: "Math Operation not implemented")
        };
    }
}