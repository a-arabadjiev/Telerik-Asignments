
namespace Boarder.Tests.Loggers
{
    using EventLogModel = Boarder.Models.EventLog;

    [TestClass]
    public class EventLogTests
    {
        [TestMethod]
        public void Constructor_Should_CreateEventLog_With_CorrectValues()
        {
            // Arrange
            string description = "Test log entry";
            DateTime currentTime = DateTime.Now;

            // Act
            EventLogModel eventLog = new EventLogModel(description);

            // Assert
            Assert.AreEqual(description, eventLog.Description);
            // Check that the time is close to the current time, allowing for a small time difference
            Assert.IsTrue((eventLog.Time - currentTime).TotalSeconds < 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_Should_ThrowArgumentNullException_When_DescriptionIsNull()
        {
            // Arrange
            string description = null;

            // Act
            EventLogModel eventLog = new EventLogModel(description);

            // This test is expected to throw an ArgumentNullException due to the null description.
        }

        [TestMethod]
        public void ViewInfo_Should_ReturnCorrectString()
        {
            // Arrange
            string description = "Test log entry";
            DateTime currentTime = DateTime.Now;
            EventLogModel eventLog = new EventLogModel(description);

            // Act
            string expected = $"[{currentTime.ToString("yyyyMMdd|HH:mm:ss.ffff")}]{description}";
            string actual = eventLog.ViewInfo();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

