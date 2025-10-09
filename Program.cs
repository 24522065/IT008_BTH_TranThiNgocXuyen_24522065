using System;
using System.Text;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.Write("Nhập kích thước mảng: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            TaoMang(arr);
            MenuChon(arr);
        }

        static void TaoMang(int[] arr)
        {
            Console.Clear();
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
                arr[i] = rnd.Next(-100, 100);

            Console.WriteLine("Mảng vừa tạo:");
            foreach (int x in arr)
                Console.Write(x + " ");
            Console.WriteLine("\n");
        }

        static void XuatMenu()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine(" (1) Tính tổng các số lẻ trong mảng");
            Console.WriteLine(" (2) Đếm số nguyên tố trong mảng");
            Console.WriteLine(" (3) Tìm số chính phương nhỏ nhất trong mảng");
            Console.WriteLine(" (4) Thoát");
            Console.WriteLine("---------------------------------------------");
        }

        static void MenuChon(int[] arr)
        {
            while (true)
            {
                XuatMenu();
                Console.Write("Nhập lựa chọn của bạn: ");
                int chon;
                if (!int.TryParse(Console.ReadLine(), out chon))
                {
                    Console.WriteLine("Vui lòng nhập số hợp lệ!\n");
                    continue;
                }

                Console.Clear();
                switch (chon)
                {
                    case 1:
                        Console.WriteLine("Tổng các số lẻ trong mảng là: " + TongSoLe(arr));
                        break;

                    case 2:
                        Console.WriteLine("Số lượng số nguyên tố trong mảng là: " + DemSoNguyenTo(arr));
                        break;

                    case 3:
                        int min = SoChinhPhuongNhoNhat(arr);
                        if (min == -1)
                            Console.WriteLine("Không có số chính phương trong mảng!");
                        else
                            Console.WriteLine("Số chính phương nhỏ nhất là: " + min);
                        break;

                    case 4:
                        Console.WriteLine("Kết thúc chương trình!");
                        return;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }

                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static int TongSoLe(int[] arr)
        {
            int tong = 0;
            foreach (int x in arr)
                if (x % 2 != 0)
                    tong += x;
            return tong;
        }

        static bool LaNguyenTo(int x)
        {
            if (x < 2) return false;
            for (int i = 2; i <= Math.Sqrt(x); i++)
                if (x % i == 0)
                    return false;
            return true;
        }

        static int DemSoNguyenTo(int[] arr)
        {
            int dem = 0;
            foreach (int x in arr)
                if (LaNguyenTo(x))
                    dem++;
            return dem;
        }

        static bool LaSoChinhPhuong(int x)
        {
            if (x < 0) return false;
            int can = (int)Math.Sqrt(x);
            return can * can == x;
        }

        static int SoChinhPhuongNhoNhat(int[] arr)
        {
            int min = int.MaxValue;
            bool found = false;

            foreach (int x in arr)
                if (LaSoChinhPhuong(x))
                {
                    found = true;
                    if (x < min)
                        min = x;
                }

            return found ? min : -1;
        }
    }
}
