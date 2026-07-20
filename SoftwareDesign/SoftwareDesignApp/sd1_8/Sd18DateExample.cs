using System.Globalization;

namespace SoftwareDesign.sd1_8;

public class Sd18DateExample
{
    private const string DateString = "2024-05-13 14:30:00";
    private const string Format = "yyyy-MM-dd HH:mm:ss";

    public void GetDate()
    {
        var date = DateTime.TryParseExact(DateString, Format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime);

        if (date)
        {
            Console.WriteLine($"Date: {dateTime.ToString(Format, CultureInfo.InvariantCulture)}");
        }
        
        Console.WriteLine($"Wrong date");
    }
}