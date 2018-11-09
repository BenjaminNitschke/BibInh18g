using NUnit.Framework;

namespace PasswordVerifier
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        [Test]
        public void Nothing()
        {
        }

        [Test]
        public void PasswordShouldNotBeNull()
        {
            string password = null;

            bool isNull = checkPasswordNull(password);

            Assert.That(isNull, Is.True);
        }

        // Assign
        [TestCase("abc", false)]
        [TestCase("12345678", true)]
        [TestCase("123456789", true)]
        public void PasswordMustBe8Characters(string password, bool expected)
        {
            // Act
            bool isValidPassword = checkPasswordLength(password);

            // Assert
            Assert.That(isValidPassword, Is.EqualTo(expected));
        }

        // Assign
        [TestCase("Test123456", true)]
        [TestCase("test123456", false)]
        public void PasswordShouldHaveAtLeastOneUppercaseLetter(string password, bool expected)
        {
            // Act
            bool isValidPassword = Verify(password);

            // Assert
            Assert.That(isValidPassword, Is.EqualTo(expected));
        }

        // Assign
        [TestCase("TESt123456", true)]
        [TestCase("TEST123456", false)]
        public void PasswordShouldHaveAtLeastOneLowercaseLetter(string password, bool expected)
        {
            // Act
            bool isValidPassword = Verify(password);

            // Assert
            Assert.That(isValidPassword, Is.EqualTo(expected));
        }

        // Assign
        [TestCase("TESt123456", true)]
        [TestCase("Test", false)]
        public void PasswordShouldContainAtLeastOneNumber(string password, bool expected)
        {
            // Act
            bool isValidPassword = checkContainsNumber(password);

            // Assert
            Assert.That(isValidPassword, Is.EqualTo(expected));
        }

        private bool Verify(string password)
        {
            // Password not null
            if (password == null)
                return false;

            // Password >= 8 characters
            if (!checkPasswordLength(password))
                return false;

            // At least one uppercase character
            if (!checkUppercase(password))
                return false;

            // At least one lowercase character
            if (!checkLowercase(password))
                return false;

            // Contains at least one number
            if (!checkContainsNumber(password))
                return false;

            return true;
        }

        private bool checkPasswordNull(string password)
        {
            if (password == null)
                return true;
            else
                return false;
        }

        private bool checkPasswordLength(string password)
        {
            if (password.Length < 8)
                return false;
            else
                return true;
        }

        private bool checkUppercase(string password)
        {
            bool minOneIsUpper = false;
            foreach (char c in password)
            {
                if (char.IsUpper(c))
                    minOneIsUpper = true;
            }

            return minOneIsUpper;
        }

        private bool checkLowercase(string password)
        {
            bool minOneIsLower = false;
            foreach (char c in password)
            {
                if (char.IsLower(c))
                    minOneIsLower = true;
            }

            return minOneIsLower;
        }

        private bool checkContainsNumber(string password)
        {
            bool containsNumber = false;
            foreach (char c in password)
            {
                if (c >= '0' && c <= '9')
                    containsNumber = true;
            }

            return containsNumber;
        }
    }
}
