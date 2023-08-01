namespace _01._Moody
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputArr = Console.ReadLine().Split('d').ToArray();
            string lastDay = inputArr[inputArr.Length - 1];

            List<string> moodsAsString = lastDay.Split(' ').ToList();

            if (moodsAsString[0] == "")
            {
                moodsAsString.RemoveAt(0);
            }
            if (moodsAsString.Count == 0)
            {
                moodsAsString.Add("0");
            }

            List<int> moodsArray = new List<int>();

            if (moodsAsString[moodsAsString.Count - 1] != "")
            {
                moodsArray = moodsAsString.Select(int.Parse).ToList();
            }
            else
            {
                moodsArray.Add(0);
            }

            int moodsSum = moodsArray.Sum();

            if (moodsSum >= 0)
            {
                Console.WriteLine($"happy {moodsSum}");
            }
            else if (moodsSum < 0)
            {
                Console.WriteLine($"sad {moodsSum}");
            }
        }
    }
}