using System;

namespace Task_11
{
    class Program
    {
        static void Main()
        {
            string[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int[] num = new int[array.Length];
            int k = 0, l_sum = 0, r_sum = 0;
            bool isExist = false;
            foreach (var q in array)
            {
                num[k] = Convert.ToInt32(q);
                ++k;
            }
            if (num.Length == 1)
            {
                Console.WriteLine("0");
            }
            else
            {
                for (int i = 0; i < num.Length; ++i)
                {
                    l_sum = r_sum = 0;
                    if (i != 0)
                    {
                        for (int j = i - 1; j >= 0; j--)
                        {
                            l_sum += num[j];
                        }
                        for (int j = i + 1; j < num.Length; j++)
                        {
                            r_sum += num[j];
                        }
                        if (l_sum == r_sum)
                        {
                            Console.WriteLine(i);
                            isExist = true;
                            break;
                        }
                    }

                }
                if (!isExist) Console.WriteLine("no");
            }

            Console.ReadKey();
        }
    }
}