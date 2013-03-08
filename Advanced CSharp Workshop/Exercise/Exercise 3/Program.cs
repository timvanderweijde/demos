using System;

namespace Exercise_3
{
    internal class Program
    {
        public enum SortType
        {
            Ascending,
            Descending
        }

        private static void Main(string[] args)
        {
            var numbers = new[] {3, 4, 6, 2, 1, 9, 7, 5};

            BubbleSort(numbers, SortType.Ascending);

            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.ReadKey();
        }

        public static void BubbleSort(int[] items, SortType sortOrder)
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
                    switch (sortOrder)
                    {
                        case SortType.Ascending:
                            if (items[j - 1] > items[j])
                            {
                                temp = items[j - 1];
                                items[j - 1] = items[j];
                                items[j] = temp;
                            }

                            break;

                        case SortType.Descending:
                            if (items[j - 1] < items[j])
                            {
                                temp = items[j - 1];
                                items[j - 1] = items[j];
                                items[j] = temp;
                            }

                            break;
                    }
                }
            }
        }
    }
}