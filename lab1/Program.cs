using System;

namespace Lab1
{
    class Programm
    {
        static void Main(string[] args)
        {
            int[] firstСheckout = { 5, 3, 4 };
            Console.WriteLine("HW1. QueueTime([5, 3, 4], 1) Время обслуживания всех покупателей: " + HW1.QueueTime(firstСheckout, 1));

            int[] secondСheckout = { 10, 2, 3, 3 };
            Console.WriteLine("HW1. QueueTime([10, 2, 3, 3], 2) Время обслуживания всех покупателей: " + HW1.QueueTime(secondСheckout, 2));

            int[] thirdСheckout = { 2, 3, 10 };
            Console.WriteLine("HW1. QueueTime([2, 3, 10], 2) Время обслуживания всех покупателей: " + HW1.QueueTime(thirdСheckout, 2));
        } 
    }
    public class HW1
    {
        public static long QueueTime(int[] customers, int n)
        {
            int[] threadsPool = new int[n];
            int time = 0;

            for (int j = 0; j < n; j++)
            {
                threadsPool[j] = customers[j];
            }

            int check = n;

            while (check < customers.Length)
            {
                int minBuyerTime = threadsPool[0];

                for (int j = 1; j < n; j++)
                {
                    if (threadsPool[j] < minBuyerTime)
                    {
                        minBuyerTime = threadsPool[j];
                    }
                }

                for (int j = 0; j < n; j++)
                {
                    threadsPool[j] -= minBuyerTime;
                }

                time += minBuyerTime;

                for (int j = 0; j < n; j++)
                {
                    if (threadsPool[j] == 0 && check < customers.Length)
                    {
                        threadsPool[j] = customers[check];
                        check++;
                    }
                }
            }

            if (customers.Length < n)
            {
                n = customers.Length;
            }

            int max = 0;

            for (int j = 0; j < n; j++)
            {
                if (threadsPool[j] > max)
                {
                    max = threadsPool[j];
                }
            }

            return time + max;
        }
    }
}