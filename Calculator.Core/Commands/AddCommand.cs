using Calculator.Core.Commands.Interfaces;
using Calculator.Core.Model;

namespace Calculator.Core.Commands;

public class AddCommand : IAddCommand
{
    public ResultModel Add(double value1, double value2)
    {
        var result = value1 + value2;
        return new ResultModel(true, result);
    }
}