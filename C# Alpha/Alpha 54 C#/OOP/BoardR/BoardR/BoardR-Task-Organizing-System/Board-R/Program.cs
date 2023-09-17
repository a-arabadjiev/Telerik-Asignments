using Board_R.Models;
using Board_R.Models.Enums;

namespace Board_R
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var item = new BoardItem("Refactor this mess", DateTime.Now.AddDays(2));
            item.AdvanceStatus(); // properly changing the status
            item.AdvanceStatus();
            Console.WriteLine(item.ViewInfo()); // Status: InProgress

            item.status = Status.Open; // ??
            Console.WriteLine(item.ViewInfo()); // Status: Open
        }
    }
}