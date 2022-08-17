using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputTasks = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] inputThreads = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int taskToKill = int.Parse(Console.ReadLine());

            Stack<int> tasks = new Stack<int>(inputTasks);
            Queue<int> threads = new Queue<int>(inputThreads);

            bool killedT = false;
            while (!killedT)
            {
                for (int i = 0; i < tasks.Count; i++)
                {

                    if (tasks.Peek() == taskToKill)
                    {
                        Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskToKill}");
                        killedT = true;
                        break;
                    }

                    else
                    {
                        for (int p = 0; p < threads.Count; p++)
                        {
                            bool killed = threads.Peek() >= tasks.Peek();

                            if (tasks.Peek() == taskToKill)
                            {
                                break;
                            }

                            else if (killed)
                            {
                                threads.Dequeue();
                                tasks.Pop();
                            }
                            else
                            {
                                threads.Dequeue();
                            }
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(' ', threads));
        }
    }
}
