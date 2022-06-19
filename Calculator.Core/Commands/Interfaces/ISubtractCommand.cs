using Calculator.Core.Model;

namespace Calculator.Core.Commands.Interfaces;

public interface ISubtractCommand
{
    ResultModel Subtract(double value1, double value2);
}