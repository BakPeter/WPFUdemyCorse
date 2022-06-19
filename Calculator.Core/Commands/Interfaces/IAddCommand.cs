using Calculator.Core.Model;

namespace Calculator.Core.Commands.Interfaces;

public interface IAddCommand
{
    ResultModel Add(double value1, double value2);
}