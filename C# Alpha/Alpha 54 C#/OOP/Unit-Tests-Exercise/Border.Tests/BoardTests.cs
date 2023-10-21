using Moq;
using Boarder.Loggers;
using Boarder.Models;
using Boarder;

namespace Border.Tests
{
    using TaskModel = Boarder.Models.Task;

    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void AddItem_Should_AddItemToBoard()
        {
            // Arrange
            int initialCount = Board.TotalItems;
            BoardItem item = new TaskModel("Test Task", "Assignee", DateTime.Now.AddHours(1));

            // Act
            Board.AddItem(item);

            // Assert
            Assert.AreEqual(initialCount + 1, Board.TotalItems);
        } 

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddItem_Should_ThrowInvalidOperationException_When_ItemAlreadyExists()
        {
            // Arrange
            BoardItem item = new TaskModel("Test Task", "Assignee", DateTime.Now.AddHours(1));
            Board.AddItem(item);

            // Act
            Board.AddItem(item); // Attempt to add the same item again

            // This test is expected to throw an InvalidOperationException due to the item already existing.
        }

        [TestMethod]
        public void LogHistory_Should_LogHistoryForAllItems()
        {
            // Arrange
            var mockLogger = new Mock<ILogger>();
            BoardItem item1 = new TaskModel("Task 1", "Assignee 1", DateTime.Now.AddHours(1));
            BoardItem item2 = new TaskModel("Task 2", "Assignee 2", DateTime.Now.AddHours(1));
            Board.AddItem(item1);
            Board.AddItem(item2);

            // Act
            Board.LogHistory(mockLogger.Object);

            // Assert
            mockLogger.Verify(logger => logger.Log(item1.ViewHistory()), Times.Once());
            mockLogger.Verify(logger => logger.Log(item2.ViewHistory()), Times.Once());
        }
    }
}
