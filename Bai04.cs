using System;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            int thang, nam;

            while (true)
            {
                Console.Write("Nhap thang (1-12): ");
                if (int.TryParse(Console.ReadLine(), out thang) && thang >= 1 && thang <= 12)
                    break;
                else
                    Console.WriteLine("Thang khong hop le. Vui long nhap lai tu 1-12!.\n");
            }

            while (true)
            {
                Console.Write("Nhap nam: ");
                if (int.TryParse(Console.ReadLine(), out nam) && nam > 0)
                    break;
                else
                    Console.WriteLine("Nam khong hop le. Vui long nhap lai.\n");
            }

            int soNgay;

            switch (thang)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    soNgay = 31;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    soNgay = 30;
                    break;
                case 2:
                    if ((nam % 400 == 0) || (nam % 4 == 0 && nam % 100 != 0))
                        soNgay = 29;
                    else
                        soNgay = 28;
                    break;
                default:
                    Console.WriteLine("Thang khong hop le!");
                    return;
            }

            Console.WriteLine($"Thang {thang} nam {nam} co {soNgay} ngay.");
        }
    }
}

