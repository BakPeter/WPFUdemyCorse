using Calculator.Core.Model;

namespace Calculator.Core.Services.Interfaces;

public interface ICalculatorService
{
    ResultModel Calculate(CalculateOperationModel calculateOperationModel);
}