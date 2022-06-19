namespace Calculator.Core.Model;

public record ResultModel(bool OperationSuccess, double Result = 0, string ErrorMessage = "");
