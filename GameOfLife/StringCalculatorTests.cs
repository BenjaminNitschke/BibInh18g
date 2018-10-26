using System;
using NUnit.Framework;

namespace GameOfLife
{
  public class StringCalculatorTests
  {
    [TestCase("", 0)]
    [TestCase("1", 1)]
    [TestCase("3", 3)]
    [TestCase("3+3", 6)]
    public void CheckCalculator(string numbers, int expected)
    {
      var calculator = new StringCalculator();
      Assert.That(calculator.Add(numbers), Is.EqualTo(expected));
    }
  }

  public class StringCalculator
  {
    public int Add(string numbers)
    {
      if (numbers == "")
        return 0;
      string[] parts = numbers.Split('+');
      int result = 0;
      for (int i = 0; i < parts.Length; i++)
        result += int.Parse(parts[i]);
      return result;
    }
  }

}
