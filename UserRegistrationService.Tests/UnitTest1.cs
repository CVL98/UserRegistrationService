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
            string password = "password123";

            // Act
            var result = service.RegisterUser(username, email, password);

            // Assert
            Assert.IsTrue(result.Contains("successfully registered"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterUser_DuplicateUsername_ThrowsArgumentException()
        {
            // Arrange
            var service = new UserRegistrationService();
            string username = "existinguser";
            string email = "newuser@example.com";
            string password = "password123";
            service.RegisterUser(username, email, password); // Register existing user

            // Act
            service.RegisterUser(username, "anotheremail@example.com", "anotherpassword"); // Try to register with same username

            // Assert
            // Expects an ArgumentException to be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterUser_InvalidEmailFormat_ThrowsArgumentException()
        {
            // Arrange
            var service = new UserRegistrationService();
            string username = "newuser";
            string email = "invalidemail"; // Invalid email format
            string password = "password123";

            // Act
            service.RegisterUser(username, email, password);

            // Assert
            // Expects an ArgumentException to be thrown
        }

    }
}
