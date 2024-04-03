namespace UserRegistrationService
{
    public class UserRegistrationService
    {
        private List<User> Users = new List<User>();

        public string RegisterUser(string username, string email, string password)
        {
            // Validate input parameters and register the user
            AddUser(username, email, password);

            // Return a confirmation message
            return $"User '{username}' successfully registered.";
        }

        private void AddUser(string username, string email, string password)
        {
            // Validate input parameters
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            // Validate username length and characters
            if (username.Length < 5 || username.Length > 20)
            {
                throw new ArgumentException("Username must be between 5 and 20 characters long");
            }

            if (!username.All(char.IsLetterOrDigit))
            {
                throw new ArgumentException("Username must contain only alphanumeric characters");
            }

            // Validate email format
            if (!IsValidEmail(email))
            {
                throw new ArgumentException("Invalid email format");
            }

            // Validate password length and special characters
            if (password.Length < 8)
            {
                throw new ArgumentException("Password must be at least 8 characters long");
            }

            if (!password.Any(char.IsSymbol))
            {
                throw new ArgumentException("Password must contain at least one special character");
            }

            // Check if the user already exists
            if (Users.Exists(u => u.Name == username))
            {
                throw new ArgumentException("User already exists");
            }

            // Add the user if it doesn't already exist
            Users.Add(new User(username, email, password));
        }

        private bool IsValidEmail(string email)
        {
            // This regular expression pattern is a basic check for email format
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, pattern);
        }
    }

}
