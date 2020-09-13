using System;

namespace Task_7
{
    class Program
    {
        static void Main()
        {
            string[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = new int[array.Length];
            int i = 0, start = 0, l = 1, Start = 0, Len = 1;
            foreach (var q in array)
            {
                numbers[i] = Convert.ToInt32(q);
                ++i;
            }
            for (int j = 1; j < numbers.Length; ++j)
            {
                if (numbers[j] > numbers[j - 1])
                {
                    l++;
                    if (l > Len)
                    {
                        Len = l;
                        Start = start;
                    }

                }
                else
                {
                    start = j;
                    l = 1;
                }
            }
            //Console.Write($"{bestLen} - {bestStart}");
            for (int j = Start; j < Start + Len; ++j)
            {
                Console.Write($"{numbers[j]} ");
            }

            Console.ReadKey();
        }
    }
}
