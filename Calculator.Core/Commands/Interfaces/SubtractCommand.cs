using Calculator.Core.Model;

namespace Calculator.Core.Commands.Interfaces;
public class SubtractCommand: ISubtractCommand
{
    public ResultModel Subtract(double value1, double value2)
    {
        var result = value1 - value2;
        return new ResultModel(true, result);
    }
}
