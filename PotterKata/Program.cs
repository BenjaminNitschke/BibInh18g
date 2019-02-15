using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterKata
{
    class Program
    {
        private BookCalculator calculator;
        private decimal pricePerBook = 8m;

        public Program()
        {
            calculator = new BookCalculator();
        }

        [Test]
        public void Nothing()
        {
        }

        [Test]
        public void BuyNoBook()
        {
            Assert.That(calculator.Calculate(), Is.EqualTo(0));
        }

        [TestCase(0)]
        [TestCase(6)]
        public void BuyWrongBook(int bookNumber)
        {
            Assert.That(calculator.Calculate(bookNumber), Is.EqualTo(0));
        }

        [Test]
        public void BuyOneBook()
        {
            Assert.That(calculator.Calculate(1), Is.EqualTo(8));
        }

        [TestCase(1, 1)]
        [TestCase(3, 3, 3)]
        [TestCase(5, 5, 5, 5, 5)]
        public void BuySameBooks(params int[] numbers)
        {
            // Arange
            BookCalculator calculator = new BookCalculator();
            decimal targetPrice = numbers.Length * pricePerBook;

            // Act
            decimal result = calculator.Calculate(numbers);

            // Assert
            Assert.That(result, Is.EqualTo(targetPrice));
        }

        [TestCase(1, 2)]
        [TestCase(5, 3)]
        [TestCase(1, 4)]
        // Two different books give a 5% discount
        public void BuyTwoDifferentBooks(params int[] numbers)
        {
            // Arange
            BookCalculator calculator = new BookCalculator();
            decimal targetPrice = 2m * 8m * 0.95m;

            // Act
            decimal result = calculator.Calculate(numbers);

            // Assert
            Assert.That(result, Is.EqualTo(targetPrice));
        }

        static void Main(string[] args)
        {
            new Program();
        }
    }
}
