﻿using Calculator.Core.Model;

namespace Calculator.Core.Commands.Interfaces;

public class AddCommand : IAddCommand
{
    public ResultModel Add(double value1, double value2)
    {
        var result = value1 + value2;
        return new ResultModel(true, result);
    }
}