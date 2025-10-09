using System;

namespace Bai05
{
    class Program
    {
        static void Main(string[] args)
        {
            int day, month, year;
            DateTime date;

            while (true)
            {
                Console.Write(" - Date: ");
                if (!int.TryParse(Console.ReadLine(), out day) || day <= 0 || day>31)
                {
                    Console.WriteLine("Ngay khong hop le. Vui long nhap lai!\n");
                    continue;
                }

                Console.Write(" - Month: ");
                if (!int.TryParse(Console.ReadLine(), out month) || month < 1 || month > 12)
                {
                    Console.WriteLine("Thang khong hop le. Vui long nhap lai!\n");
                    continue;
                }

                Console.Write(" - Year: ");
                if (!int.TryParse(Console.ReadLine(), out year) || year <= 0)
                {
                    Console.WriteLine("Nam khong hop le. Vui long nhap lai!\n");
                    continue;
                }

                try
                {
                    date = new DateTime(year, month, day);
                    break; 
                }
                catch
                {
                    Console.WriteLine($"Ngay {day}/{month}/{year} khong hop le! Vui long nhap lai.\n");
                }
            }

            Console.WriteLine($"\nNgay {day}/{month}/{year} la {date.DayOfWeek}.");
        }
    }
}


