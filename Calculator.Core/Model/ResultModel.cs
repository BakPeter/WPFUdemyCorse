namespace Calculator.Core.Model;

public record ResultModel(bool Success, double Result = 0, string ErrorMessage = "");
