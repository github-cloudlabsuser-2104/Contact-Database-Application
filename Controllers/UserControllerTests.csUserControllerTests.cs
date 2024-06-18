using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRUD_application_2.Tests.Controllers
{
    [TestClass]
    public class UserControllerTests
    {
        // Helper method to initialize UserController with sample data
        private UserController InitializeController()
        {
            UserController controller = new UserController();
            // Clear existing user list and add sample data
            UserController.userlist = new List<User>
            {
                new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com" },
                new User { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com" }
            };
            return controller;
        }

        [TestMethod]
        public void Index_ReturnsViewWithListOfUsers()
        {
            // Arrange
            var controller = InitializeController();

            // Act
            var result = controller.Index() as ViewResult;
            var model = result.Model as List<User>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(model);
            Assert.AreEqual(2, model.Count); // Adjust count based on sample data
        }

        // Other unit tests for CRUD operations...

        // Example of another test method:
        [TestMethod]
        public void Details_ValidId_ReturnsViewWithUser()
        {
            // Arrange
            var controller = InitializeController();
            int userId = 1;

            // Act
            var result = controller.Details(userId) as ViewResult;
            var model = result.Model as User;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(model);
            Assert.AreEqual(userId, model.Id);
        }
    }
}
