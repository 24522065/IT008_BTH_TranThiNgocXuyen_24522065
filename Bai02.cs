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
            int n;

            while (true)
            {
                Console.Write("Nhap so nguyen duong n: ");
                if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                    break;
                else
                    Console.WriteLine("Gia tri khong hop le! Vui long nhap lai so nguyen duong.");
            }

            int tong = 0;
            for (int i = 2; i < n; i++)
            {
                if (SoNguyenTo(i))
                    tong += i;
            }

            Console.WriteLine("Tong cac so nguyen to < n: " + tong);
        }
    }
}

