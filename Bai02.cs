using System;
namespace _02
{
    class Program
    {
        static bool SoNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
                if (n % i == 0) return false;
            return true;
        }

        static void Main()
        {
            Console.WriteLine("Nhap so nguyen duong n: ");
            int n = int.Parse(Console.ReadLine());
            int tong = 0;
            for (int i = 2; i < n; i++)
            {
                if (SoNguyenTo(i))
                {
                    tong += i;
                }
            }
            Console.WriteLine("Tong cac so nguyen to <n: " + tong);
        }
    }
}
