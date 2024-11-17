namespace eTicaret.Application;

public sealed class EmailNotUniqueException : Exception
{
    public EmailNotUniqueException() : base("Mail adresi daha önce kullanılmış") { }
}
