namespace UserRegistrationService.Tests
{
    [TestClass]
    public class UserRegistrationServiceTests
    {
        [TestMethod]
        public void RegisterUser_ValidData_ReturnsConfirmationMessage()
        {
            // Arrange
            var service = new UserRegistrationService();
            string username = "testuser";
            string email = "testuser@example.com";
            string password = "password123!";

            // Act
            var result = service.RegisterUser(username, email, password);

            // Assert
            Assert.IsTrue(result.Contains("successfully registered"));
        }

        [TestMethod]
        public void RegisterUser_DuplicateUsername_ThrowsArgumentException()
        {
            // Arrange
            var service = new UserRegistrationService();
            string username = "existinguser";
            string email = "newuser@example.com";
            string password = "password123!";
            service.RegisterUser(username, email, password); // Register existing user

            // Act and Assert
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                service.RegisterUser(username, "anotheremail@example.com", "anotherpassword!"); // Try to register with same username
            });

            // Assert
            Assert.AreEqual("User already exists", exception.Message);
        }

        [TestMethod]
        public void RegisterUser_InvalidPassword_ThrowsArgumentException()
        {
            // Arrange
            var service = new UserRegistrationService();
            string username = "newuser";
            string email = "newuser@example.com";

            // Invalid passwords and their expected exception messages
            var invalidPasswords = new Dictionary<string, string>
    {
        { "weak", "Password must be at least 8 characters long" },
        { "password123", "Password must contain at least one special character" }
    };

            foreach (var invalidPassword in invalidPasswords)
            {
                // Act and Assert
                var exception = Assert.ThrowsException<ArgumentException>(() =>
                {
                    service.RegisterUser(username, email, invalidPassword.Key);
                });

                // Assert
                Assert.AreEqual(invalidPassword.Value, exception.Message);
            }
        }


        [TestMethod]
        public void RegisterUser_InvalidEmailFormat_ThrowsArgumentException()
        {
            // Arrange
            var service = new UserRegistrationService();
            string username = "newuser";
            string email = "invalidemail"; // Invalid email format
            string password = "password123!";

            // Act and Assert
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                service.RegisterUser(username, email, password);
            });

            // Assert
            Assert.AreEqual("Invalid email format", exception.Message);
        }


    }
}
