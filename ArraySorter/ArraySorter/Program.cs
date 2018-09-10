using System;
//my goal in this app is to compare performance of array sorting in three different ways. If I need sort really big array, I would prefere to use Fast sotr.
namespace ArraySorter
{
    class Sorting
    {
        static int add2pyramid(int[] arr, int i, int N)
        {
            int imax;
            int buf;
            if ((2 * i + 2) < N)
            {
                if (arr[2 * i + 1] > arr[2 * i + 2]) imax = 2 * i + 2;
                else imax = 2 * i + 1;
            }
            else imax = 2 * i + 1;
            if (imax >= N) return i;
            if (arr[i] > arr[imax])
            {
                buf = arr[i];
                arr[i] = arr[imax];
                arr[imax] = buf;
                if (imax < N / 2) i = imax;
            }
            return i;
        }

        static int[] PyramidSorting(int[] arr, int len)
        {
            for (int i = len / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = add2pyramid(arr, i, len);
                if (prev_i != i) ++i;
            }

            int buf;
            for (int k = len - 1; k > 0; --k)
            {
                buf = arr[0];
                arr[0] = arr[k];
                arr[k] = buf;
                int i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = add2pyramid(arr, i, k);
                }
            }
            return arr;
        }

        static int[] FastSorting(int[] arr, long first, long last)
        {
            double p = arr[(last - first) / 2 + first];
            int temp;
            long i = first, j = last;
            while (i <= j)
            {
                while (arr[i] > p && i <= last) ++i;
                while (arr[j] < p && j >= first) --j;
                if (i <= j)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    ++i; --j;
                }
            }
            if (j > first) FastSorting(arr, first, j);
            if (i < last) FastSorting(arr, i, last);
            return arr;
        }
        //show only first 150 integers because array could be 1 Gb weight
        static void Display(int[] array)
        {
            for (int i = 0; i < 150; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        static int[] СombSort(int[] input)
        {
            double gap = input.Length;
            bool swaps = true;
            while (gap > 1 || swaps)
            {
                gap /= 1.247330950103979;
                if (gap < 1) { gap = 1; }
                int i = 0;
                swaps = false;
                while (i + gap < input.Length)
                {
                    int igap = i + (int)gap;
                    if (input[i] < input[igap])
                    {
                        int swap = input[i];
                        input[i] = input[igap];
                        input[igap] = swap;
                        swaps = true;
                    }
                    i++;
                }
            }
            return input;
        }
        static string read = "";

        //as long as it is test Method, I send to my sort methods only Clone of Array. This is how I figure out saving initial array's sequence to send it in other methods. I do understand that it will cause damage of performance, so I will not repeat it with really big array
        public static void Test(int[] array)
        {
            while (read != "q")
            {
                Console.WriteLine("\n\nEnter your way to sort array: \n1.Fast sort;\n2.Pyramid sort;\n3.Comb sort;\nq. Quit.");
                read = Console.ReadLine();
                int[] sorted;
                DateTime dt1 = DateTime.Now;
                switch (read)
                {
                    case "1":
                        sorted = FastSorting((int[])array.Clone(), 0, array.Length - 1);
                        Console.WriteLine($"fast sort took  {DateTime.Now - dt1}");
                        Display(sorted);
                        break;
                    case "2":
                        sorted = PyramidSorting((int[])array.Clone(), array.Length);
                        Console.WriteLine($"pyramid sort took  {DateTime.Now - dt1}");
                        Display(sorted);
                        break;
                    case "3":
                        sorted = СombSort((int[])array.Clone());
                        Console.WriteLine($"combo sort took  {DateTime.Now - dt1}");
                        Display(sorted);
                        break;
                    default:
                        Console.WriteLine(read != "q" ? "enter something else" : "");
                        Test(array);
                        break;

                }
            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] initArray = new int[] { 3, 4, 50, 100, 200, 0, 10, 20, 30, 500, 10, 302, 10, 0, 1, 20, 3, 5, 345, 2, 12, 345, 456, 3, 56, 45, 2, 6, 0, 2, 6, 7, 2, 3, 4, 0, 10, 5, 67, 20, 4, 20, 111, 123, 53, 23, 778, 45, 3, 400, 10, 302, 10, 0, 1, 20, 3, 5, 345, 2, 12, 345, 456, 3, 56, 45, 2, 6, 0, 2, 6, 7, 2, 3, 4, 0, 10, 5, 67, 20, 4, 20, 111, 123, 4, 50, 100, 200, 0, 10, 20, 30, 500, 10, 302, 10, 0, 1, 20, 3, 5, 345, 2, 12, 345, 456, 3, 56, 45, 2, 6, 0, 2, 6, 7, 2, 3, 4, 0, 10, 5, 67, 20, 4, 20, 111, 123, 53, 23, 778, 45, 3, 400, 10, 302, 10, 0, 1, 20, 3, 5, 345, 2, 12, 345, 456, 3, 56, 45, 2, 6, 0, 2, 6, 7, 2, 3, 4, 0, 10, 5, 67, 20, 4, 20, 111, 123, 53, 23, 778, 0, 10, 302, 10, 0, 1, 20, 3, 5, 345, 2, 12, 345, 456, 3, 56, 45, 2, 6, 0, 2, 6, 7, 2, 3, 4, 0, 10, 5, 67, 20, 4, 20, 111, 123, 53, 23, 778, 45, 3, 67, 8, 34, 8, 3, 4, 5, 2, 3, 7, 845, 3, 67, 8, 34, 8, 3, 4, 5, 2, 3, 7, 867, 8, 34, 8, 3, 4, 5, 2, 3, 7, 8, 20, 304, 10, 2, 30, 4, 05, 660, 234, 102, 5053, 23, 778, 0, 10, 302, 10, 0, 1, 20, 3, 5, 345, 2, 12, 345, 456, 3, 56, 45, 2, 6, 0, 2, 6, 7, 2, 3, 4, 0, 10, 5, 67, 20, 4, 20, 111, 123, 53, 23, 778, 45, 3, 67, 8, 34, 8, 3, 4, 5, 2, 3, 7, 845, 3, 67, 8, 34, 8, 3, 4, 5, 2, 3, 7, 867, 8, 34, 8, 3, 4, 5, 2, 3, 7, 8, 20, 304, 10, 2, 30, 4, 05, 660, 234, 102, 50, 50, 100, 200, 0, 10, 20, 30, 500, 4, 50, 100, 200, 0, 10, 20, 30, 5004, 50, 100, 200, 0, 10, 20, 30, 500, 7, 2, 3, 4, 0, 10, 5, 67, 20, 4, 20, 111, 123, 53, 23, 778, 0, 10, 302, 10, 0, 1, 20, 3, 5, 345, 2, 12, 345, 456, 3, 56, 100, 200, 0, 10, 20, 30, 500, 10, 302, 10, 0, 1, 20, 3, 5, 345, 2, 12, 345, 456, 3, 56, 45, 2, 6, 0, 2, 6, 7, 2, 3, 4, 0, 10, 5, 67, 20, 4, 20, 111, 123, 53, 23, 778, 45, 3, 400, 10, 302, 10, 0, 1, 20, 3, 5, 345, 2, 12, 345, 456, 3, 56, 45, 2, 6, 0, 2, 6, 7, 2, 3, 4, 0, 10, 5, 67, 20, 4, 20, 111, 123, 4, 50, 100, 200, 0, 10, 20, 30, 500, 10, 302, 10, 0, 1, 20, 3, 5, 345, 2, 12, 345, 456, 3, 56, 45, 2, 6, 0, 2, 6, 7, 2, 3, 4, 0, 10, 5, 67, 20, 4, 20, 111, 123, 53, 23, 778, 45, 3, 400, 10, 302, 10, 0, 1, 20, 3, 5, 345, 2, 12, 345, 456, 3, 56, 45, 2, 6, 0, 2, 6, 7, 2, 3, 4, 0, 10, 5, 67, 20, 4, 20, 111, 123, 53, 23, 778, 0, 10, 302, 10, 0, 1, 20, 3, 5, 345, 2, 12, 345, 456, 3, 56, 45, 2, 6, 0, 2, 6, 7, 2, 3, 4, 0, 10, 5, 67, 20, 4, 20, 111, 123, 53, 23, 778, 45, 3, 67, 8, 34, 8, 3, 4, 5, 2, 3, 7, 845, 3, 67, 8, 34, 8, 3, 4, 5, 2, 3, 7, 867, 8, 34, 8, 3, 4, 5, 2, 3, 7, 8, 20, 304, 10, 2, 30, 4, 05, 660, 234, 102, 5053, 23, 778, 0, 10, 302, 10, 0, 1, 20, 3, 5, 345, 2, 12, 345, 456, 3, 56, 45, 2, 6, 0, 2, 6, 7, 2, 3, 4, 0, 10, 5, 67, 20, 4, 20, 111, 123, 53, 23, 778, 45, 3, 67, 8, 34, 8, 3, 4, 5, 2, 3, 7, 845, 3, 67, 8, 34, 8, 3, 4, 5, 2, 3, 7, 867, 8, 34, 8, 3, 4, 5, 2, 3, 7, 8, 20, 304, 10, 2, 30, 4, 05, 660, 234, 102, 50, 50, 100, 200, 0, 10, 20, 30, 500, 4, 50, 100, 200, 0, 10, 20, 30, 5004, 50, 100, 200, 0, 10, 20, 30, 500, 7, 2, 3, 4, 0, 10, 5, 67, 20, 4, 20, 111, 123, 53, 23, 778, 0, 10, 302, 10, 0, 1, 20, 3, 5, 345, 2, 12, 345, 456, 3, 56 };

            Console.WriteLine("unsorted array:");
            foreach (var n in initArray)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine("\n");

            Sorting.Test(initArray);
        }
    }
}
