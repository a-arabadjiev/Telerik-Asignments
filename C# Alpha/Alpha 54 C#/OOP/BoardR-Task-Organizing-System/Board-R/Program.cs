﻿using Board_R.Models;
using Board_R.Models.Enums;

namespace Board_R
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
                var item = new BoardItem("Refactor this mess", DateTime.Now.AddDays(2));
                item.DueDate = item.DueDate.AddYears(2);
                item.Title = "Not that important";
                item.RevertStatus();
                item.AdvanceStatus();
                item.RevertStatus();

                Console.WriteLine(item.ViewHistory());

                Console.WriteLine("\n--------------\n");

                var anotherItem = new BoardItem("Don't refactor anything", DateTime.Now.AddYears(10));
                anotherItem.AdvanceStatus();
                anotherItem.AdvanceStatus();
                anotherItem.AdvanceStatus();
                anotherItem.AdvanceStatus();
                anotherItem.AdvanceStatus();
                Console.WriteLine(anotherItem.ViewHistory());
            }
            catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
            }
        }
    }
}