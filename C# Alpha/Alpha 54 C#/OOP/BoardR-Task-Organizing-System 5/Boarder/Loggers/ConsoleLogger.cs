namespace Boarder.Loggers
{
    using System;
    using Boarder.Loggers.Contracts;

    public class ConsoleLogger : ILogger
    {
        public void Log(string value)
        {
            Console.WriteLine(value);
        }
    }
}
