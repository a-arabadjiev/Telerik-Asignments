using Boarder.Models;

namespace Boarder.Tests.Models
{
    using TaskModel = Boarder.Models.Task;
    [TestClass]
    public class TaskTests
    {
        [TestMethod]
        public void Constructor_Should_ThrowException_When_TitleIsNullOrWhitespace()
        {
            //Arrange
            string emptyStringTitle = string.Empty;
            string nullStringTitle = null;
            string assignee = "TestUser";
            DateTime dueDate = Convert.ToDateTime("01-01-2030");

            //Act

            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
                new TaskModel(emptyStringTitle, assignee, dueDate));
            Assert.ThrowsException<ArgumentException>(() =>
                new TaskModel(nullStringTitle, assignee, dueDate));
        }

        [TestMethod]
        public void Constructor_Should_ThrowException_When_TitleIsOutOfValidRange()
        {
            //Arrange
            string lowRangeTitle = "asd";
            string highRangeTitle = "asdasdasdasdasdasdasdasdasdasdasd";
            string assignee = "TestUser";
            DateTime dueDate = Convert.ToDateTime("01-01-2030");

            //Act

            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
                new TaskModel(lowRangeTitle, assignee, dueDate));
            Assert.ThrowsException<ArgumentException>(() =>
                new TaskModel(highRangeTitle, assignee, dueDate));
        }

        [TestMethod]
        public void Constructor_Should_ThrowException_When_DueDateIsInThePast()
        {
            //Arrange
            string title = "This is a test title";
            string assignee = "TestUser";
            DateTime pastDueDate = Convert.ToDateTime("01-01-2020");

            //Act

            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
                new TaskModel(title, assignee, pastDueDate));
        }




        [TestMethod]
        // Constructor
        public void Constructor_Should_CreateTask_With_CorrectValues()
        {
            //Arrange
            string title = "This is a test title";
            string assignee = "TestUser";
            DateTime dueDate = Convert.ToDateTime("01-01-2030");

            //Act
            TaskModel sut = new TaskModel(title, assignee, dueDate);

            //Assert
            Assert.AreEqual(title, sut.Title);
            Assert.AreEqual(Status.Todo, sut.Status);
        }

        // Test invalid assignee (null)
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Should_ThrowException_When_AssigneeIsNull()
        {
            // Arrange
            string title = "Invalid Assignee Test";
            string assignee = null;
            DateTime dueDate = Convert.ToDateTime("01-01-2030");

            // Act
            TaskModel sut = new TaskModel(title, assignee, dueDate);
        }

        // Test invalid assignee (empty string)
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Should_ThrowException_When_AssigneeIsEmpty()
        {
            // Arrange
            string title = "Invalid Assignee Test";
            string assignee = "";
            DateTime dueDate = Convert.ToDateTime("01-01-2030");

            // Act
            TaskModel sut = new TaskModel(title, assignee, dueDate);
        }

        // Test advancing status
        [TestMethod]
        public void AdvanceStatus_Should_AdvanceStatus_When_NotVerified()
        {
            // Arrange
            string title = "Status Advance Test";
            string assignee = "TestUser";
            DateTime dueDate = Convert.ToDateTime("01-01-2030");
            TaskModel sut = new TaskModel(title, assignee, dueDate);

            // Act
            sut.AdvanceStatus();

            // Assert
            Assert.AreEqual(Status.InProgress, sut.Status);
        }

        // Test status cannot advance beyond Verified
        [TestMethod]
        public void AdvanceStatus_Should_NotAdvanceStatusBeyondVerified()
        {
            // Arrange
            string title = "Status Advance Test";
            string assignee = "TestUser";
            DateTime dueDate = Convert.ToDateTime("01-01-2030");
            TaskModel sut = new TaskModel(title, assignee, dueDate);

            // Act
            sut.AdvanceStatus(); // Todo to InProgress
            sut.AdvanceStatus(); // InProgress to Completed
            sut.AdvanceStatus(); // Completed to Verified
            sut.AdvanceStatus(); // Try to advance beyond Verified

            // Assert
            Assert.AreEqual(Status.Verified, sut.Status); // Status should stay at Verified
        }

        [TestMethod]
        public void RevertStatus_Should_LogEvent_When_StatusChanges()
        {
            // Arrange
            string title = "Test Task";
            string assignee = "Assignee";
            DateTime dueDate = DateTime.Now.AddHours(1);
            TaskModel task = new TaskModel(title, assignee, dueDate);

            // Act
            task.AdvanceStatus();
            task.RevertStatus();

            // Assert
            // Create a method to get the history logs or use any public method that retrieves logs
            string history = task.ViewHistory();
            StringAssert.Contains(history, "Task: 'Test Task'");
            StringAssert.Contains(history, "Task changed from InProgress to Todo");
        }

        [TestMethod]
        public void AdvanceStatus_Should_LogEvent_When_StatusChanges()
        {
            // Arrange
            string title = "Test Task";
            string assignee = "Assignee";
            DateTime dueDate = DateTime.Now.AddHours(1);
            TaskModel task = new TaskModel(title, assignee, dueDate);

            // Act
            task.AdvanceStatus();

            // Assert
            // Create a method to get the history logs or use any public method that retrieves logs
            string history = task.ViewHistory();
            StringAssert.Contains(history, "Task: 'Test Task'");
            StringAssert.Contains(history, "Task changed from Todo to InProgress");
        }

        [TestMethod]
        public void Constructor_Should_ThrowException_When_AssigneeTooShort()
        {
            // Arrange
            string title = "Test Task";
            string invalidAssignee = "A"; // Too short
            DateTime dueDate = DateTime.Now.AddHours(1);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new TaskModel(title, invalidAssignee, dueDate));
        }

        [TestMethod]
        public void Constructor_Should_ThrowException_When_AssigneeTooLong()
        {
            // Arrange
            string title = "Test Task";
            string invalidAssignee = "ThisAssigneeNameIsTooLongAndShouldExceed30Characters"; // Too long
            DateTime dueDate = DateTime.Now.AddHours(1);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new TaskModel(title, invalidAssignee, dueDate));
        }

        [TestMethod]
        public void AssigneeProperty_Should_SetAndRetrieve_AssigneeCorrectly()
        {
            // Arrange
            string title = "Test Task";
            string initialAssignee = "InitialAssignee";
            string newAssignee = "NewAssignee";
            DateTime dueDate = DateTime.Now.AddHours(1);
            TaskModel task = new TaskModel(title, initialAssignee, dueDate);

            // Act
            task.Assignee = newAssignee;

            // Assert
            Assert.AreEqual(newAssignee, task.Assignee);
        }

        [TestMethod]
        public void DueDate_Should_NotAllow_PastDueDates()
        {
            // Arrange
            string title = "Test Task";
            string assignee = "TestAssignee";
            DateTime pastDueDate = DateTime.Now.AddHours(-1); // Past due date

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new TaskModel(title, assignee, pastDueDate));
        }

        [TestMethod]
        public void ViewInfo_Should_Return_CorrectFormat()
        {
            // Arrange
            string title = "Test Task";
            string assignee = "TestAssignee";
            DateTime dueDate = DateTime.Now.AddHours(1);
            TaskModel task = new TaskModel(title, assignee, dueDate);

            // Act
            string expected = $"Task: '{title}', [Todo|{dueDate:dd-MM-yyyy}] Assignee: {assignee}";
            string actual = task.ViewInfo();

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}