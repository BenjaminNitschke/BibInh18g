using System;
using NUnit.Framework;

namespace _190215HarryPotterBooks
{
    class Program
    {
        //Ein Buch kostet 8€
        //Zwei Bücher: 5% Rabatt
        //Drei Bücher: 10% Rabatt
        //Rabatt erhöht sich ab 4 Büchern immer um 10%
        //Sonderfälle?

        private static float price = 8f;
        public static float discount = 10f;
        public static float maxDiscount = 40f;
        public static float discountPrice;
        public static int amount;

        public static float DiscountPrice(float discount)
        {
            if (amount == 2)
            {
                discount /= 2;
            }
            else if (amount > 3)
            {
                for (int i = 3; i < amount; i++)
                {
                    discount += discount;
                }
            }

            if(discount > maxDiscount)
            {
                discount = maxDiscount;
            }

            discountPrice = price - ((discount * price) / 100);

            return discountPrice;
        }

        public static void CalculateDiscount()
        {
            Console.WriteLine("How many books would you like to buy?");

            amount = int.Parse(Console.ReadLine());

            Console.WriteLine(amount);

            if(amount == 0)
            {
                Console.WriteLine("Ok, see you again!");
            }
            else if(amount == 1)
            {
                Console.WriteLine("That would be " + price + " Euros.");
            }
            else if(amount > 1)
            {
                DiscountPrice(discount);
                Console.WriteLine("That would be " + discountPrice + " Euros.");
            }
        }

        static void Main(string[] args)
        {
            CalculateDiscount();
        }

        [Test]
        public void Nothing()
        {

        }
    }
}
