namespace eTicaret.Domain.Tests.UnitTest;
public sealed class Test
{
    public Result Method()
    {
        //return Result.Succeed("asdasd");
        //return ("asdasd", true);
        return "bla bla";
    }
}

public class Result
{
    public bool IsSuccessful { get; set; }
    public string Message { get; set; }

    public static Result Succeed(string message)
    {
        return new Result() { Message = message };
    }

    public static implicit operator Result(string message)
    {
        return new Result() { Message = message, IsSuccessful = true };
    }

    public static implicit operator Result((string message, bool issuccessful) parameters)
    {
        return new Result() { Message = parameters.message, IsSuccessful = parameters.issuccessful };
    }
}
