using System;
using System.Linq;

namespace lesson2
{ 
    public class BinarySearcher
    {
        private int[] list;

        public BinarySearcher(int[] list) {
            this.list = list.ToArray();
        }

        public int Find(int item) {
            if (this.list.Length == 0) return -1;
           
            int min = 0;
            int max = this.list.Length - 1;
            while( min <= max) {
                int middle = (min + max) / 2;
                if(list[middle] == item) {
                    return middle;
                }
                if(list[middle] > item)
                {
                    max = middle - 1;
                }
                else
                {
                    min = middle + 1;
                }
            }
            return -1;
        }

        private void SortList() => QuickSort(this.list, 0, this.list.Length - 1);

        private void QuickSort(int[] array, int min, int max) {
            if (min >= max) return;
            int c = Partition(array, min, max);
            QuickSort(array, min, c - 1);
            QuickSort(array, c + 1, max);
        }

        private int Partition(int[] array, int min, int max) {
            int i = min;
            for (int j = min; j < max; j++)
            {
                if (array[j].CompareTo(array[max]) <= 0)
                {
                    int t = array[i];
                    array[i] = array[j];
                    array[j] = t;
                    i++;
                }
            }
            return i - 1;
        }

    }
}
