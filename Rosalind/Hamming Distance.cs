using System;
using System.IO;
using System.Collections.Generic;

namespace Rosalind
{
	public class Problem5
	{
		public static void Hamming_Distance()
		{
			//variable declaration
			string line;
			int counter = 0;
			string sequence1 = "";
			string sequence2 = "";
			//opens the file for reading 
			StreamReader file =
				new StreamReader(File.Open("/Users/ross.blanchard/Downloads/rosalind_hamm.txt", FileMode.Open, FileAccess.ReadWrite));
			//assigns line 1 to sequence 1 and line 2 to sequence 2
			while ((line = file.ReadLine()) != null)
			{
				if (counter == 0)
					sequence1 = line;
				else 
					sequence2 = line;
				counter++;
			}
			file.Dispose();
			//converts the strings to character arrays
			char[] arr_sequence1 = sequence1.ToCharArray();
			char[] arr_sequence2 = sequence2.ToCharArray();

			//compares the arrays at each index to see if theyre the same, then increment the mismatches variable each time they dont match
			int mismatches = 0;
			for (int comparisonIndex = 0; comparisonIndex < arr_sequence1.Length; comparisonIndex++)
			{
				if (arr_sequence1[comparisonIndex] != arr_sequence2[comparisonIndex])
				{
					mismatches++;
				}
			}
			Console.WriteLine(mismatches);
		}
	}
}
