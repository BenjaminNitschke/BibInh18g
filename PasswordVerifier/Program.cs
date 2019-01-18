using NUnit.Framework;
using System.Linq;

namespace PasswordVerifier
{
    class Program
    {
        static void Main()
        {

        }
        //assign
        [TestCase("aBc1", false)]
        [TestCase("HalloEcho1", true)]
        [TestCase(null, false)]
        [TestCase("wwwwwwwwwwww1", false)]
        [TestCase("WWWWWWWWWWWW1", false)]
        [TestCase("WWWWWWWWwwwwww", false)]
        public void PasswordMustBe8Chars(string password, bool expected)
        {
            //act
            bool isValidPassword = Verify(password);
            //assert
            Assert.That(isValidPassword, Is.EqualTo(expected));
        }


        public bool Verify(string password)
        {
            if (password == null)
            {
                return false;
            }

            if (!password.Any(char.IsUpper))
            {
                return false;
            }

            if (!password.Any(char.IsLower))
            {
                return false;
            }

            if (!password.Any(char.IsDigit))
            {
                return false;
            }

            if (password.Length < 8)
            {
                return false;
            }

            return true;
        }
    }
}
