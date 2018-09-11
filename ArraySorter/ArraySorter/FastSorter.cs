using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySorter
{
    class FastSorter : ISorter
    {
        int[] _sort(int[] arr, long first, long last)
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
            if (j > first) _sort(arr, first, j);
            if (i < last) _sort(arr, i, last);
            return arr;
        }
        public int[] Sort(int[] array)
        {
            return _sort(array, 0, array.Length - 1);
        }
        public override string ToString()
        {
            return "Fast sorter";
        }
    }
}
