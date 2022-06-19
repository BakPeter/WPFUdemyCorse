using Calculator.Core.Model;

namespace Calculator.Core.Commands.Interfaces;

public interface IAdditionCommand
{
    ResultModel Add(double value1, double value2);
}