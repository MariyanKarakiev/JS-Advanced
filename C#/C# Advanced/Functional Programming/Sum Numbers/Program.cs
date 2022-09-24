using System;
using System.Linq;

namespace Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int[]> readN = readN => readN
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            Action<int> printCount = p => Console.WriteLine(p);

            PrintSum(readN(Console.ReadLine()), printCount);

        }
        static void PrintSum(int[] nums, Action<int> print)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }
            print(nums.Length);
            print(sum);
        }
    }
}
