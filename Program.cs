using System;
namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            int thang, nam;
            Console.WriteLine("Nhap thang (1-12): ");
            thang = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap nam: ");
            nam = int.Parse(Console.ReadLine());

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