using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boarder.Tests
{
    using Boarder.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    namespace Border.Tests
    {
        using IssueModel = Boarder.Models.Issue;

        [TestClass]
        public class IssueTests
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
                    new IssueModel(emptyStringTitle, assignee, dueDate));
                Assert.ThrowsException<ArgumentException>(() =>
                    new IssueModel(nullStringTitle, assignee, dueDate));
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
                    new IssueModel(lowRangeTitle, assignee, dueDate));
                Assert.ThrowsException<ArgumentException>(() =>
                    new IssueModel(highRangeTitle, assignee, dueDate));
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
                    new IssueModel(title, assignee, pastDueDate));
            }




            [TestMethod]
            public void Constructor_Should_CreateIssue_With_CorrectValues()
            {
                // Arrange
                string title = "Test Issue";
                string description = "This is a test issue";
                DateTime dueDate = DateTime.Now.AddDays(1); // Due date should be in the future

                // Act
                IssueModel issue = new IssueModel(title, description, dueDate);

                // Assert
                Assert.AreEqual(title, issue.Title);
                Assert.AreEqual(description, issue.Description);
                Assert.AreEqual(Status.Open, issue.Status);
                Assert.AreEqual(dueDate, issue.DueDate);
            }

            [TestMethod]
            public void Constructor_Should_UseDefaultDescription_When_DescriptionIsNull()
            {
                // Arrange
                string title = "Test Issue";
                string description = null;
                DateTime dueDate = DateTime.Now.AddDays(1); // Due date should be in the future

                // Act
                IssueModel issue = new IssueModel(title, description, dueDate);

                // Assert
                Assert.AreEqual("No desciption", issue.Description);
            }

            [TestMethod]
            public void AdvanceStatus_Should_AdvanceStatusToVerified()
            {
                // Arrange
                string title = "Test Issue";
                string description = "This is a test issue";
                DateTime dueDate = DateTime.Now.AddDays(1); // Due date should be in the future
                IssueModel issue = new IssueModel(title, description, dueDate);

                // Act
                issue.AdvanceStatus();

                // Assert
                Assert.AreEqual(Status.Verified, issue.Status);
            }

            [TestMethod]
            public void AdvanceStatus_Should_NotAdvanceStatusBeyondVerified()
            {
                // Arrange
                string title = "Test Issue";
                string description = "This is a test issue";
                DateTime dueDate = DateTime.Now.AddDays(1); // Due date should be in the future
                IssueModel issue = new IssueModel(title, description, dueDate);

                // Act
                issue.AdvanceStatus(); // Set to Verified
                issue.AdvanceStatus(); // Try to advance beyond Verified

                // Assert
                Assert.AreEqual(Status.Verified, issue.Status); // Status should stay at Verified
            }

            [TestMethod]
            public void RevertStatus_Should_RevertStatusToOpen()
            {
                // Arrange
                string title = "Test Issue";
                string description = "This is a test issue";
                DateTime dueDate = DateTime.Now.AddDays(1); // Due date should be in the future
                IssueModel issue = new IssueModel(title, description, dueDate);

                // Act
                issue.RevertStatus();

                // Assert
                Assert.AreEqual(Status.Open, issue.Status);
            }

            [TestMethod]
            public void RevertStatus_Should_NotRevertStatusBelowOpen()
            {
                // Arrange
                string title = "Test Issue";
                string description = "This is a test issue";
                DateTime dueDate = DateTime.Now.AddDays(1); // Due date should be in the future
                IssueModel issue = new IssueModel(title, description, dueDate);

                // Act
                issue.RevertStatus(); // Set to Open
                issue.RevertStatus(); // Try to revert below Open

                // Assert
                Assert.AreEqual(Status.Open, issue.Status); // Status should stay at Open
            }

            [TestMethod]
            public void ViewInfo_Should_ReturnCorrectString()
            {
                // Arrange
                string title = "Test Issue";
                string description = "This is a test issue";
                DateTime dueDate = DateTime.Now.AddDays(1); // Due date should be in the future
                IssueModel issue = new IssueModel(title, description, dueDate);

                // Act
                string expected = $"Issue: '{title}', [{issue.Status}|{dueDate:dd-MM-yyyy}] Description: {description}";
                string actual = issue.ViewInfo();

                // Assert
                Assert.AreEqual(expected, actual);
            }
        }
    }
}

