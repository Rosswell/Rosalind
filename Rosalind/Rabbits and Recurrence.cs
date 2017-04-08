using System;
using System.IO;

namespace Rosalind
{
	public class Problem18
	{
		public static void RabbitsNReccurence()
		{
			string line;
			Console.WriteLine("what is the suffix to the rosalind file?");
			string dir = Console.ReadLine();
			// Read the file and display it line by line.
			Directory.SetCurrentDirectory("/Users/ross.blanchard/Downloads/");
			StreamReader file =
				new StreamReader(File.Open("rosalind_" + dir + ".txt", FileMode.Open, FileAccess.ReadWrite));
			line = file.ReadLine();

			string[] PhenotypeArray = line.Split(' ');

			var months = Convert.ToInt32(PhenotypeArray[0]);
			var pairs = Convert.ToInt32(PhenotypeArray[1]);

			long firstNumber = 1;
			long secondNumber = 1;
			long thirdNumber = 0;
			long pairMultiplier = 0;
			long sum = 0;

			for (int currentMonth = 3; currentMonth <= months; currentMonth++)
			{
				pairMultiplier = (pairs - 1) * firstNumber;
				thirdNumber = firstNumber + secondNumber + pairMultiplier;
				firstNumber = secondNumber;
				secondNumber = thirdNumber;
				sum = thirdNumber;
			}
			Console.WriteLine(sum);
		}
	}
}
