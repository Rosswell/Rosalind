using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Rosalind
{
	public class GC_Content_2
	{
		public static void GC_Contents()
		{
			string line;

			// Read the file and display it line by line.
			StreamReader file =
				new StreamReader(File.Open("/Users/ross.blanchard/Downloads/rosalind_gc.txt", FileMode.Open, FileAccess.ReadWrite));
			int titleIndex = 0;
			int ATCGIndex = 0;
			int GCIndex = 0;
			List<string> ATCG = new List<string>();
			List<string> titles = new List<string>();
			List<string> sequence = new List<string>();
			List<double> GCprecentage = new List<double>();
			int counter = 0;

			//while the file contains lines, parse those lines
			while ((line = file.ReadLine()) != null)
			{
				//if the line is the title of the sequence, add it to the titles list
				if (line.StartsWith(">"))
				{
					//removes the ">" from the title
					string newLine = line.Remove(0, 1);
					titles.Insert(titleIndex, newLine);
					titleIndex++;
					//to prevent the sequence index from iterating before it's filled with sequence - only applicable to the first line
					if (counter > 0)
					{
						//concatenate the whole list into one string, and add it to the final sequence list. empty the intermediate list
						ATCG.Insert(ATCGIndex, string.Join("", sequence));
						sequence.Clear();
						ATCGIndex++;
					}
				}
				//if the line is not a title line, add it to an intermediate list
				if (!line.StartsWith(">"))
				{
					sequence.Add(line);
				}
				counter++;
			}
			ATCG.Insert(ATCGIndex, string.Join("", sequence));
			file.Dispose();
			//calculates the GC percentage within the sequences and then writes them to a list, GCpercentage
			foreach (string element in ATCG)
			{
				int count = element.Count(g => g == 'G');
				int count2 = element.Count(c => c == 'C');
				double elementLength = element.Length;
				//Console.WriteLine(elementLength);
				double GCpercent = 100 * (count + count2) / elementLength;
				//GCprecentage.Add(GCpercent);
				GCprecentage.Insert(GCIndex, GCpercent);
				GCIndex++;
			}
			/* prints out all the titles and GC percentages
			for (int writingIndex = 0; writingIndex < ATCGIndex; writingIndex++)
			{
				Console.WriteLine("{0}\n{1}", titles[writingIndex], GCprecentage[writingIndex]);
			}
			*/
			//finds the index of the maximum GC percentage
			int maxGCIndex = (GCprecentage.IndexOf(GCprecentage.Max()));
			//returns the title and the GC percentage of the highest GC value
			Console.WriteLine("{0}\n{1}", titles[maxGCIndex], GCprecentage[maxGCIndex]);
		}
	}
}
