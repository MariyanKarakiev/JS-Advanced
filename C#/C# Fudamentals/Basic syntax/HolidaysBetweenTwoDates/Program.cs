using System;
using System.Globalization;

class HolidaysBetweenTwoDates
{
    static void Main()
    {
        var startDate = DateTime.ParseExact(Console.ReadLine(), "d.M.yyyy", CultureInfo.InvariantCulture);
        var endDate = DateTime.ParseExact(Console.ReadLine(), "d.M.yyyy", CultureInfo.InvariantCulture);
        var holidaysCount = 0;               
       
        while ( startDate <= endDate)
        {
           
            if (startDate.DayOfWeek == DayOfWeek.Saturday || startDate.DayOfWeek == DayOfWeek.Sunday)
            {
                holidaysCount++;
            }
            startDate = startDate.AddDays(1);
        }
        Console.WriteLine(holidaysCount);
    }
}
