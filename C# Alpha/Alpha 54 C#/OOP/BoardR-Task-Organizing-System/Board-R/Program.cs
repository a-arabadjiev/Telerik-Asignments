namespace Board_R
{
    using Board_R.Models;
    using Board_R.Models.Enums;

    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
                var issue = new Issue("App flow tests?", "We need to test the App!", DateTime.Now.AddDays(1));
                issue.AdvanceStatus();
                issue.DueDate = issue.DueDate.AddDays(1);
                Console.WriteLine(issue.ViewHistory());
            }
            catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
            }
        }
    }
}