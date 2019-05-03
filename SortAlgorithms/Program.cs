using System;
using NUnit.Framework;

namespace SortAlgorithms
{
	public class Program
	{
		public static void Main()
		{
			Console.WriteLine("SortAlgorithms");
		}

		[Test]
		public void CheckBubbleSort()
		{
			int[] list = new[] { 5, 1, 7, 3, 8, 4 };
			BubbleSort(list);
			int[] solution = new[] { 1, 3, 4, 5, 7, 8 };
			CollectionAssert.AreEqual(solution, list);
		}

		private static void BubbleSort(int[] list)
		{
			for (var iteration = 0; iteration < list.Length - 1; iteration++)
			{
				var smallestIndex = FindSmallestIndex(list, iteration);
				Swap(list, smallestIndex, iteration);
			}
		}

		private static int FindSmallestIndex(int[] list, int iteration)
		{
			var smallest = list[iteration];
			var smallestIndex = iteration;
			for (int i=iteration+1; i<list.Length; i++)
				if (list[i] < smallest)
				{
					smallest = list[i];
					smallestIndex = i;
				}
			return smallestIndex;
		}

		private static void Swap(int[] list, int first, int second)
		{
			var rememberValue = list[first];
			list[first] = list[second];
			list[second] = rememberValue;
		}
	}
}
