namespace PersonelTakip.Application;
public static class Extensions
{
    public static bool IsIdentityNumberAvailable(this string str)
    {
        if (str.Length == 11) return true;

        return false;
    }
}
