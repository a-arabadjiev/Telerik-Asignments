using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boarder.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.IO;

    namespace Border.Tests
    {
        using ConsoleLogger = Boarder.Loggers.ConsoleLogger;

        [TestClass]
        public class ConsoleLoggerTests
        {
            [TestMethod]
            public void Log_Should_WriteToConsole()
            {
                // Arrange
                string message = "Test log message";
                ConsoleLogger logger = new ConsoleLogger();

                // Redirect the standard output to capture the console output
                StringWriter sw = new StringWriter();
                Console.SetOut(sw);

                // Act
                logger.Log(message);

                // Get the captured console output
                string consoleOutput = sw.ToString();

                // Restore the standard output
                Console.SetOut(Console.Out);

                // Assert
                StringAssert.Contains(consoleOutput, message);
            }
        }
    }

}
