namespace HesapMakinasi;
public sealed class CalculateService
{
    public int Add(int x, int y)
    {
        return x + y;
    }

    public int Subtract(int x, int y)
    {
        return x - y;
    }

    public int Divide(int x, int y)
    {
        if (y == 0)
        {
            throw new DivideException();
        }
        return x / y;
    }

    public int Multiply(int x, int y)
    {
        return x * y;
    }
}

public sealed class DivideException : Exception
{
    public DivideException() : base("0 bölünemez!")
    {
    }
}
