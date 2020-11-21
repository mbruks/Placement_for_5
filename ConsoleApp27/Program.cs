using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Threading;
namespace Placement_for_5
{
    class Program
    {
        static void swap(int[] a, int i, int j)
        {
            int s = a[i];
            a[i] = a[j];
            a[j] = s;
        }
        static bool NextSet(int[] a, int n, int m)
        {
            int j;
            do
            {
                j = n - 2;
                while (j != -1 && a[j] >= a[j + 1])
                    j--;
                if (j == -1)
                    return false;
                int k = n - 1;
                while (a[j] >= a[k])
                    k--;
                swap(a, j, k);
                int l = j + 1, r = n - 1;
                while (l < r)
                    swap(a, l++, r--);
            } while (j > m - 1);
            return true;
        }
        static void Print(int[] a, int n, StreamWriter sw)
        {
                for (int i = 0; i < n; i++)
                    //Console.Write(a[i] + " ");
                    sw.Write(a[i] + " ");
                sw.WriteLine(" ");
        }
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter(@"C:\Users\Admin\source\repos\ConsoleApp27\ConsoleApp27\txt.txt");
            //Время работы программы
            DateTime time1 = DateTime.Now;
            for (int i = 0; i < 200000000; i++) { }
            DateTime time2 = DateTime.Now;
            Console.WriteLine("Время выполнения: {0}", (time2 - time1).Milliseconds);
            int k = 0;
            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8 };
            Console.WriteLine("Введите число K = ");
            int m = int.Parse(Console.ReadLine());
            int n = a.Length;
            for (int i = 0; i < n; i++)
                a[i] = i + 1;
            Print(a, m, sw);
            k++;
            while (NextSet(a, n, m))
            {
                Print(a, m, sw);
                k++;
            }
            Console.ReadKey();
            sw.Write(k);
            sw.Close();
        }
    }
}
