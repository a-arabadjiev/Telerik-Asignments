namespace Board_R
{
    using Board_R.Models;
    using Board_R.Models.Base;

    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
                var tomorrow = DateTime.Now.AddDays(1);
                var task = new Task("Write unit tests", "Peter", tomorrow);
                var issue = new Issue("Review tests", "Someone must review Peter's tests.", tomorrow);

                Board.AddItem(task);
                Board.AddItem(issue);
                task.AdvanceStatus();
                issue.AdvanceStatus();

                Board.LogHistory();
            }
            catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
            }
        }
    }
}