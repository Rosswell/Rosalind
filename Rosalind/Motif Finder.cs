using System;
using System.IO;
using System.Collections.Generic;

namespace Rosalind
{
	public static class Problem7
	{
		public static void Motif_Finder()
		{
			string line;
			int counter = 0;
			string sequence = "";
			string motif = "";
			StreamReader file =
				new StreamReader(File.Open("/Users/ross.blanchard/Downloads/rosalind_subs.txt", FileMode.Open, FileAccess.ReadWrite));
			//assigns sequence to the string to search within and motif to the string to search for
			while ((line = file.ReadLine()) != null)
			{
				if (counter == 0)
					sequence = line;
				else
					motif = line;
				counter++;
			}
			file.Dispose();
			string totalIndices = "";
			int matchingIndex2 = 0;
			//checks at every index for a match of the motif to the sequence
			for (int startIndex = 0; startIndex < sequence.Length; startIndex++)
			{
				//assigns matchingIndex1 to the index where the match occurs
				int matchingIndex1 = sequence.IndexOf(motif, startIndex, StringComparison.CurrentCulture);
				if (matchingIndex1 != matchingIndex2)
				{
					//if the current matching index is a new match, add it to the string collecting all of the matches, plus a space.
					//does not include index == 0 since rosalind considers the start of the sequence to be 1 for some reason
					if (matchingIndex1 != 0 && matchingIndex1 != -1)
					{
						string indexString = Convert.ToString(matchingIndex1 + 1);
						totalIndices = totalIndices + indexString + " ";
					}
					//assigns the new match to be the check for subsequent matchingIndex1 assignments (prevents duplicates for each loop)
					matchingIndex2 = matchingIndex1;
				}
			}
			Console.WriteLine(totalIndices);
		}
	}
}
