using System;
using System.Globalization;

public class TakeString
{
    public static void Main()
    {
        var firstString = Console.ReadLine();
        var secondString = Console.ReadLine();

        Console.WriteLine(DateModifier.CalculateDays(firstString, secondString));
    }
}
public static class DateModifier
{
    public static long CalculateDays(string firstString, string secondString)
    {
        var firstDate = DateTime.ParseExact(firstString, "yyyy mm dd", CultureInfo.InvariantCulture);
        var secondDate = DateTime.ParseExact(secondString, "yyyy mm dd", CultureInfo.InvariantCulture);

        Console.WriteLine("\ndays between dates: ");
        return Math.Abs((firstDate - secondDate).Days);
    }
}
