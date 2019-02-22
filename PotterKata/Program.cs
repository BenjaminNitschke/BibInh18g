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
            Assert.That(calculator.Calculate(new List<int>()), Is.EqualTo(0));
        }

        //[TestCase(0)]
        //[TestCase(6)]
        //public void BuyWrongBook(int bookNumber)
        //{
        //    Assert.That(calculator.Calculate(new List<int>() { bookNumber }), Is.EqualTo(0));
        //}

        [Test]
        public void BuyOneBook()
        {
            Assert.That(calculator.Calculate(new List<int>() {1}), Is.EqualTo(8));
        }

        [TestCase(1, 1)]
        [TestCase(3, 3, 3)]
        [TestCase(5, 5, 5, 5, 5)]
        public void BuySameBooks(params int[] numbers)
        {
            decimal targetPrice = numbers.Length * pricePerBook;
            decimal result = calculator.Calculate(numbers.ToList());
            Assert.That(result, Is.EqualTo(targetPrice));
        }

        [TestCase(1, 2)]
        [TestCase(5, 3)]
        [TestCase(1, 4)]
        public void TwoDifferentBooksResultsIn5PercentDiscount(params int[] numbers)
        {
            decimal targetPrice = numbers.Length * pricePerBook * 0.95m;
            decimal result = calculator.Calculate(numbers.ToList());
            Assert.That(result, Is.EqualTo(targetPrice));
        }

        [TestCase(1, 2, 3)]
        [TestCase(5, 3, 1)]
        [TestCase(1, 4, 5)]
        public void ThreeDifferentBooksResultsIn10PercentDiscount(params int[] numbers)
        {
            decimal targetPrice = numbers.Length * pricePerBook * 0.9m;
            decimal result = calculator.Calculate(numbers.ToList());
            Assert.That(result, Is.EqualTo(targetPrice));
        }

        [TestCase(1, 2, 3, 4)]
        [TestCase(5, 3, 1, 2)]
        [TestCase(1, 4, 5, 3)]
        public void FourDifferentBooksResultsIn20PercentDiscount(params int[] numbers)
        {
            decimal targetPrice = numbers.Length * pricePerBook * 0.8m;
            decimal result = calculator.Calculate(numbers.ToList());
            Assert.That(result, Is.EqualTo(targetPrice));
        }

        [TestCase(1, 2, 3, 4, 5)]
        [TestCase(5, 3, 1, 2, 4)]
        [TestCase(1, 4, 5, 3, 2)]
        public void FiveDifferentBooksResultsIn30PercentDiscount(params int[] numbers)
        {
            decimal targetPrice = numbers.Length * pricePerBook * 0.7m;
            decimal result = calculator.Calculate(numbers.ToList());
            Assert.That(result, Is.EqualTo(targetPrice));
        }

        [TestCase(1, 2, 1, 2)]
        [TestCase(5, 5, 2, 2)]
        [TestCase(4, 4, 5, 5)]
        [TestCase(4, 5, 4, 5)]
        [TestCase(3, 1, 1, 3)]
        [TestCase(3, 1, 3, 1)]
        public void TwoTimesTwoSameBooks(params int[] numbers)
        {
            decimal targetPrice = 2 * (2 * pricePerBook * 0.95m);
            decimal result = calculator.Calculate(numbers.ToList());
            Assert.That(result, Is.EqualTo(targetPrice));
        }

        static void Main(string[] args)
        {
            new Program();
        }
    }
}
