using System;

namespace Exercise_3
{
    internal class Program
    {
        public delegate bool ComparisonDelegate(int first, int second);

        public enum SortType
        {
            Ascending,
            Descending
        }

        private static void Main(string[] args)
        {
            var numbers = new[] {3, 4, 6, 2, 1, 9, 7, 5};

            // The bubble sort method should be made more reusable by being able to 
            // supply a comparison delegate instead of a sort type.

            ComparisonDelegate ascending = (first, second) => first > second;
            ComparisonDelegate descending = (first, second) => first < second;

            BubbleSort(numbers, ascending);

            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.ReadKey();
        }

        public static void BubbleSort(int[] items, ComparisonDelegate comparison)
        {
            int i;
            int j;
            int temp;

            if (items == null)
            {
                return;
            }

            for (i = items.Length - 1; i >= 0; i--)
            {
                for (j = 1; j <= i; j++)
                {
                    if (comparison(items[j - 1], items[j]))
                    {
                        temp = items[j - 1];
                        items[j - 1] = items[j];
                        items[j] = temp;
                    }
                }
            }
        }
    }
}