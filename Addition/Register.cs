using System.Text.RegularExpressions;

namespace Jenkins_build
{
    public class Register
    {
        private readonly string namePattern = @"^[A-Za-z]{4,}$";
        private readonly string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"; 
        private readonly string passwordPattern = @"^.{7,}$"; 
        private readonly string phoneNumberPattern = @"^\d{10}$";

        public bool ValidateName(string name)
        {
            return !string.IsNullOrEmpty(name) && Regex.IsMatch(name, namePattern);
        }

        public bool ValidateEmail(string email)
        {
            return !string.IsNullOrEmpty(email) && Regex.IsMatch(email, emailPattern);
        }

        public bool ValidatePassword(string password)
        {
            return !string.IsNullOrEmpty(password) && Regex.IsMatch(password, passwordPattern);
        }

        public bool ValidatePhoneNumber(string phoneNumber)
        {
            return !string.IsNullOrEmpty(phoneNumber) && Regex.IsMatch(phoneNumber, phoneNumberPattern);
        }
    }
}
