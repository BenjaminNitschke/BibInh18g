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
            decimal targetPrice = numbers.Length * pricePerBook;
            decimal result = calculator.Calculate(numbers);
            Assert.That(result, Is.EqualTo(targetPrice));
        }

        [TestCase(1, 2)]
        [TestCase(5, 3)]
        [TestCase(1, 4)]
        public void TwoDifferentBooksResultsIn5PercentDiscount(params int[] numbers)
        {
            decimal targetPrice = 2m * 8m * 0.95m;
            decimal result = calculator.Calculate(numbers);
            Assert.That(result, Is.EqualTo(targetPrice));
        }

        static void Main(string[] args)
        {
            new Program();
        }
    }
}
