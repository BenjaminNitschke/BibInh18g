﻿using NUnit.Framework;
using System;

namespace GameOfLife
{
    class StringCalculatorTests
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            string[] values = numbers.Split('+');

            int result = 0;
            for (int i = 0; i < values.Length; i++)
                result += int.Parse(values[i]);

            return result;
        }

        [TestCase("", 0)]
        [TestCase("1", 1)]
        [TestCase("3", 3)]
        [TestCase("1+2", 3)]
        public void CheckCalculator(string numbers, int expected)
        {
            Assert.That(Add(numbers), Is.EqualTo(expected));
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

        [Test, Description("Return a single number in a string as a number")]
        public void SingleNumberInString()
        {
            // Assign
            string numbers = "1";
            int result;

            // Act
            result = Add(numbers);

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }
    }
}
