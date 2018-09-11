using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySorter
{
    class CombSorter : ISorter
    {
        int[] _sort(int[] arr)
        {
            double gap = arr.Length;
            bool swaps = true;
            while (gap > 1 || swaps)
            {
                gap /= 1.247330950103979;
                if (gap < 1) { gap = 1; }
                int i = 0;
                swaps = false;
                while (i + gap < arr.Length)
                {
                    int igap = i + (int)gap;
                    if (arr[i] < arr[igap])
                    {
                        int swap = arr[i];
                        arr[i] = arr[igap];
                        arr[igap] = swap;
                        swaps = true;
                    }
                    i++;
                }
            }
            return arr;
        }

        public int[] Sort(int[] array)
        {
            return _sort(array);
        }

        public override string ToString()
        {
            return "Comb sort";
        }
    }
}
