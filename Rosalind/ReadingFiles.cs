using System;
using System.IO;
using System.Collections.Generic;

namespace Rosalind
{
	public class ReadingFiles
	{
		public static List<string> readFasta()
		{
			string line;
			Console.WriteLine("what is the suffix to the rosalind file?");
			string dir = Console.ReadLine();
			// Read the file and display it line by line.
			Directory.SetCurrentDirectory("/Users/ross.blanchard/Downloads/");
			StreamReader file =
				new StreamReader(File.Open("rosalind_" + dir + ".txt", FileMode.Open, FileAccess.ReadWrite));
			int titleIndex = 0;
			int ATCGIndex = 0;
			List<string> ATCG = new List<string>();
			List<string> titles = new List<string>();
			List<string> sequence = new List<string>();
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
			return ATCG;
		}
	}
}
