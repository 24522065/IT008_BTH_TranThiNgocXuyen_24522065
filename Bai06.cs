using System;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, m;

            do
            {
                Console.Write("Nhap so dong n (>0): ");
                if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                {
                    Console.WriteLine("Gia tri n khong hop le. Vui long nhap lai!");
                }
            } while (n <= 0);
            do
            {
                Console.Write("Nhap so cot m (>0): ");
                if (!int.TryParse(Console.ReadLine(), out m) || m <= 0)
                {
                    Console.WriteLine("Gia tri m khong hop le. Vui long nhap lai!");
                }
            } while (m <= 0);

            int[,] a = TaoMaTranNgauNhien(n, m);

            Console.WriteLine("\n=== Ma tran duoc tao ngau nhien ===");
            XuatMaTran(a);

            int chon;
            do
            {
                Console.WriteLine("\n===== MENU MA TRAN =====");
                Console.WriteLine("1. Xuat ma tran");
                Console.WriteLine("2. Tim phan tu lon nhat / nho nhat");
                Console.WriteLine("3. Tim dong co tong lon nhat");
                Console.WriteLine("4. Tinh tong cac so KHONG phai so nguyen to");
                Console.WriteLine("5. Xoa dong thu k");
                Console.WriteLine("6. Xoa cot chua phan tu lon nhat");
                Console.WriteLine("0. Thoat");
                Console.Write("==> Chon chuc nang: ");
                chon = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (chon)
                {
                    case 1:
                        Console.WriteLine("\n=== Ma tran hien tai ===");
                        XuatMaTran(a);
                        break;
                    case 2:
                        Console.WriteLine($"Phan tu lon nhat: {TimMax(a)}");
                        Console.WriteLine($"Phan tu nho nhat: {TimMin(a)}");
                        break;
                    case 3:
                        Console.WriteLine($"Dong co tong lon nhat: {TimDongTongLonNhat(a)}");
                        break;
                    case 4:
                        Console.WriteLine($"Tong cac so KHONG phai so nguyen to: {TongKhongNguyenTo(a)}");
                        break;
                    case 5:
                        Console.Write("Nhap dong muon xoa (0..n-1): ");
                        int k = int.Parse(Console.ReadLine());
                        a = XoaDong(a, k);
                        Console.WriteLine($"Da xoa dong {k}. Ma tran moi:");
                        XuatMaTran(a);
                        break;
                    case 6:
                        a = XoaCotChuaMax(a);
                        Console.WriteLine("Da xoa cot chua phan tu lon nhat:");
                        XuatMaTran(a);
                        break;
                    case 0:
                        Console.WriteLine("Tam biet!");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }

            } while (chon != 0);
        }

        static int[,] TaoMaTranNgauNhien(int n, int m)
        {
            Random rnd = new Random();
            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    a[i, j] = rnd.Next(1, 100);
            return a;
        }

        static void XuatMaTran(int[,] a)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(a[i, j].ToString().PadLeft(5));
                Console.WriteLine();
            }
        }

        static int TimMax(int[,] a)
        {
            int max = a[0, 0];
            foreach (int x in a)
                if (x > max) max = x;
            return max;
        }

        static int TimMin(int[,] a)
        {
            int min = a[0, 0];
            foreach (int x in a)
                if (x < min) min = x;
            return min;
        }

        static int TimDongTongLonNhat(int[,] a)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            int maxSum = int.MinValue, dong = 0;

            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = 0; j < m; j++)
                    sum += a[i, j];
                if (sum > maxSum)
                {
                    maxSum = sum;
                    dong = i;
                }
            }
            return dong;
        }

        static bool LaNguyenTo(int x)
        {
            if (x < 2) return false;
            for (int i = 2; i * i <= x; i++)
                if (x % i == 0) return false;
            return true;
        }

        static int TongKhongNguyenTo(int[,] a)
        {
            int sum = 0;
            foreach (int x in a)
                if (!LaNguyenTo(x))
                    sum += x;
            return sum;
        }

        static int[,] XoaDong(int[,] a, int k)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            if (k < 0 || k >= n)
            {
                Console.WriteLine("Dong khong hop le!");
                return a;
            }

            int[,] b = new int[n - 1, m];
            int r = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == k) continue;
                for (int j = 0; j < m; j++)
                    b[r, j] = a[i, j];
                r++;
            }
            return b;
        }

        static int[,] XoaCotChuaMax(int[,] a)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            int max = TimMax(a);

            int cotMax = -1;
            for (int i = 0; i < n && cotMax == -1; i++)
                for (int j = 0; j < m; j++)
                    if (a[i, j] == max)
                    {
                        cotMax = j;
                        break;
                    }

            if (cotMax == -1) return a;

            int[,] b = new int[n, m - 1];
            for (int i = 0; i < n; i++)
            {
                int c = 0;
                for (int j = 0; j < m; j++)
                {
                    if (j == cotMax) continue;
                    b[i, c++] = a[i, j];
                }
            }
            return b;
        }
    }
}



