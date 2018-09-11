using System;
using System.Linq;
//my goal in this app is to compare performance of array sorting in three different ways. If I need sort really big array, I would
//prefere to use Fast sotr.
namespace ArraySorter
{
    public interface ISorter
    {
        int[] Sort(int[] array);
    }
    class Sorting
    {
        public static ISorter GetSortByType(string sortedType)
        {
            switch (sortedType)
            {
                case "1": return new FastSorter();
                case "2": return new PyramideSorter();
                case "3": return new CombSorter();
                default: return null;
            }
        }
    }

    class Program
    {
        static string sortType;
        public static void DoWork(int[] array)
        {
            int[] sortedArray = new int[array.Length];
            while (sortType != "q")
            {
                Console.WriteLine("\n\nEnter your way to sort array: \n1.Fast sort;\n2.Pyramid sort;\n3.Comb sort;\nq. Quit.");
                sortType = Console.ReadLine();
                ISorter sorter = Sorting.GetSortByType(sortType);
                if (sorter == null) continue;
                DateTime t1 = DateTime.Now;
                //as long as it is test Method, clone of array is sending to Sort method. This is how saving 
                //initial array's sequence for send it in other methods was figured out.It is understood that it will cause damage
                //of performance, so it won't be repeated with really big array
                sortedArray = sorter.Sort((int[])array.Clone());
                Console.WriteLine($"Array was sorted by {sorter.ToString()} and that took {DateTime.Now - t1}");
                Console.WriteLine(string.Join(", ", sortedArray.Take(150)));
            }
        }

        static void Main(string[] args)
        {
            int[] initArray = new int[] { 3, 4, 50, 100, 200, 0, 10, 20, 30, 500, 10, 302, 10, 0, 1, 20, 3, 5, 345, 2, 12, 345, 456,
                3, 56, 45, 2, 6, 0, 2, 6, 7, 2, 3, 4, 0, 10, 5, 67, 20, 4, 20, 111, 123, 53, 23, 778, 45, 3, 400, 10, 302, 10, 0, 1,
                20, 3, 5, 345, 2, 12, 345, 456, 3, 56, 45, 2, 6, 0, 2, 6, 7, 2, 3, 4, 0, 10, 5, 67, 20, 4, 20, 111, 123, 4, 50, 100,
                200, 0, 10, 20, 30, 500, 10, 302, 10, 0, 1, 20, 3, 5, 345, 2, 12, 345, 456, 3, 56, 45, 2, 6, 0, 2, 6, 7, 2, 3, 4, 0,
                10, 5, 67, 20, 4, 20, 111, 123, 53, 23, 778, 45, 3, 400, 10, 302, 10, 0, 1, 20, 3, 5, 345, 2, 12, 345, 456, 3, 56,
                45, 2, 6, 0, 2, 6, 7, 2, 3, 4, 0, 10, 5, 67, 20, 4, 20, 111, 123, 53, 23, 778, 0, 10, 302, 10, 0, 1, 20, 3, 5, 345,
                2, 12, 345, 456, 3, 56, 45, 2, 6, 0, 2, 6, 7, 2, 3, 4, 0, 10, 5, 67, 20, 4, 20, 111, 123, 53, 23, 778, 45, 3, 67, 8,
                34, 8, 3, 4, 5, 2, 3, 7, 845, 3, 67, 8, 34, 8, 3, 4, 5, 2, 3, 7, 867, 8, 34, 8, 3, 4, 5, 2, 3, 7, 8, 20, 304, 10, 2,
                30, 4, 05, 660, 234, 102, 5053, 23, 778, 0, 10, 302, 10, 0, 1, 20, 3, 5, 345, 2, 12, 345, 456, 3, 56, 45, 2, 6, 0,
                2, 6, 7, 2, 3, 4, 0, 10, 5, 67, 20, 4, 20, 111, 123, 53, 23, 778, 45, 3, 67, 8, 34, 8, 3, 4, 5, 2, 3, 7, 845, 3, 67,
                8, 34, 8, 3, 4, 5, 2, 3, 7, 867, 8, 34, 8, 3, 4, 5, 2, 3, 7, 8, 20, 304, 10, 2, 30, 4, 05, 660, 234, 102, 50, 50,
                100, 200, 0, 10, 20, 30, 500, 4, 50, 100, 200, 0, 10, 20, 30, 5004, 50, 100, 200, 0, 10, 20, 30, 500, 7, 2, 3, 4, 0,
                10, 5, 67, 20, 4, 20, 111, 123, 53, 23, 778, 0, 10, 302, 10, 0, 1, 20, 3, 5, 345, 2, 12, 345, 456, 3, 56, 100, 200,
                0, 10, 20, 30, 500, 10, 302, 10, 0, 1, 20, 3, 5, 345, 2, 12, 345, 456, 3, 56, 45, 2, 6, 0, 2, 6, 7, 2, 3, 4, 0, 10,
                5, 67, 20, 4, 20, 111, 123, 53, 23, 778, 45, 3, 400, 10, 302, 10, 0, 1, 20, 3, 5, 345, 2, 12, 345, 456, 3, 56, 45,
                2, 6, 0, 2, 6, 7, 2, 3, 4, 0, 10, 5, 67, 20, 4, 20, 111, 123, 4, 50, 100, 200, 0, 10, 20, 30, 500, 10, 302, 10, 0,
                1, 20, 3, 5, 345, 2, 12, 345, 456, 3, 56, 45, 2, 6, 0, 2, 6, 7, 2, 3, 4, 0, 10, 5, 67, 20, 4, 20, 111, 123, 53, 23,
                778, 45, 3, 400, 10, 302, 10, 0, 1, 20, 3, 5, 345, 2, 12, 345, 456, 3, 56, 45, 2, 6, 0, 2, 6, 7, 2, 3, 4, 0, 10, 5,
                67, 20, 4, 20, 111, 123, 53, 23, 778, 0, 10, 302, 10, 0, 1, 20, 3, 5, 345, 2, 12, 345, 456, 3, 56, 45, 2, 6, 0, 2,
                6, 7, 2, 3, 4, 0, 10, 5, 67, 20, 4, 20, 111, 123, 53, 23, 778, 45, 3, 67, 8, 34, 8, 3, 4, 5, 2, 3, 7, 845, 3, 67, 8,
                34, 8, 3, 4, 5, 2, 3, 7, 867, 8, 34, 8, 3, 4, 5, 2, 3, 7, 8, 20, 304, 10, 2, 30, 4, 05, 660, 234, 102, 5053, 23,
                778, 0, 10, 302, 10, 0, 1, 20, 3, 5, 345, 2, 12, 345, 456, 3, 56, 45, 2, 6, 0, 2, 6, 7, 2, 3, 4, 0, 10, 5, 67, 20,
                4, 20, 111, 123, 53, 23, 778, 45, 3, 67, 8, 34, 8, 3, 4, 5, 2, 3, 7, 845, 3, 67, 8, 34, 8, 3, 4, 5, 2, 3, 7, 867, 8,
                34, 8, 3, 4, 5, 2, 3, 7, 8, 20, 304, 10, 2, 30, 4, 05, 660, 234, 102, 50, 50, 100, 200, 0, 10, 20, 30, 500, 4, 50,
                100, 200, 0, 10, 20, 30, 5004, 50, 100, 200, 0, 10, 20, 30, 500, 7, 2, 3, 4, 0, 10, 5, 67, 20, 4, 20, 111, 123, 53,
                23, 778, 0, 10, 302, 10, 0, 1, 20, 3, 5, 345, 2, 12, 345, 456, 3, 56 };
            
            Console.WriteLine("unsorted array:");
            Console.WriteLine(string.Join(", ", initArray.Take(150)));
            Console.WriteLine("\n");
            DoWork(initArray);
        }
    }
}
