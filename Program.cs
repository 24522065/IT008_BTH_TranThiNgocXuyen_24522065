using System;
namespace _3
{
    class Program
    {
        static bool laNamNhuan(int nam)
        {
            return (nam % 400 == 0) || (nam % 4 == 0 && nam % 100 != 0);
        }
        static bool NgayHopLe(int ngay, int thang, int nam)
        {
            if (nam < 1 || thang < 1 || thang > 12 || ngay < 1)
            {
                return false;
            }
            int[] soNgayTrongThang = { 0, 31, 28, 31, 30, 31, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (laNamNhuan(nam))
            {
                soNgayTrongThang[2] = 29;
            }
            if (ngay > soNgayTrongThang[thang])
            {
                return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap ngay: ");
            int ngay = int.Parse(Console.ReadLine());

            Console.WriteLine("Nhap thang: ");
            int thang = int.Parse(Console.ReadLine());

            Console.WriteLine("Nhap nam: ");
            int nam = int.Parse(Console.ReadLine());

            if (NgayHopLe(ngay, thang, nam))
                Console.WriteLine($"Ngay {ngay}/{thang}/{nam} la ngay hop le.");
            else
                Console.WriteLine($"Ngay {ngay}/{thang}/{nam} khong hop le.");
        }
    }

}

