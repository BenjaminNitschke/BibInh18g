using System.Linq;
using NUnit.Framework;

namespace PasswordVerifier
{
	class Program
	{
		static void Main()
		{
		}
		
		//PasswordShouldNotBeNull
		[TestCase(null, false)]
		//PasswordMustBe8Characters
		[TestCase("abc", false)]
		[TestCase("Ab23843902", true)]
		//password should have one uppercase letter at least -> string.ToCharArray() foreach (var ch) char.IsUpper
		[TestCase("abcabcabc", false)]
		[TestCase("Am2345678", true)]
		//password should have one lowercase letter at least -> string.ToCharArray() foreach (var ch)char.IsLower
		[TestCase("ABCTEUDAO", false)]
		//password should have one number at least -> foreach (var ch) char >= '0' && char <= '9'
		[TestCase("abcsodeAE", false)]
		public void AssertPasswordIsValid(string password, bool expected)
		{
			Assert.That(Verify(password), Is.EqualTo(expected));
		}

		public bool Verify(string password)
		{
			if (password == null)
				return false;
			if (password.Length < 8)
				return false;
			if (!password.Any(char.IsUpper))
				return false;
			if (!password.Any(char.IsLower))
				return false;
			if (!password.Any(char.IsDigit))
				return false;
			return true;
		}
	}
}
