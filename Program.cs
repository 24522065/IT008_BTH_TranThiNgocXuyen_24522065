using System;

namespace Bai05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(" - Date: ");
            int day = int.Parse(Console.ReadLine());

            Console.Write(" - Month: ");
            int month = int.Parse(Console.ReadLine());

            Console.Write(" - Year: ");
            int year = int.Parse(Console.ReadLine());

            try
            {
                DateTime date = new DateTime(year, month, day);

                Console.WriteLine($"  {day}/{month}/{year} is {date.DayOfWeek}");
            }
            catch
            {
                Console.WriteLine($"  {day}/{month}/{year} is invalid");
            }
        }
    }
}
