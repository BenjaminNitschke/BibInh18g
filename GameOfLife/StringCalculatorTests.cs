using NUnit.Framework;

namespace GameOfLife
{
    class StringCalculatorTests
    {
        public int Add(string numbers)
        {
            //int[] values = numbers.Split('-');
            return 0;
        }

        [Test, Description("Empty string should return zero")]
        public void Empty_String()
        {
            // Assign
            string numbers = "";
            int result;

            // Act
            result = Add(numbers);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
