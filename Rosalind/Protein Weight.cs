using System;
using System.IO;

namespace Rosalind
{
	public class Problem12
	{
		public static void proteinWeight()
		{
			//Open the file and allow RW
			StreamReader file =
				new StreamReader(File.Open("/Users/ross.blanchard/Downloads/rosalind_prtm.txt", FileMode.Open, FileAccess.ReadWrite));
			//while the file contains lines, parse the one sequence into a string. 

			string line = file.ReadLine();

			file.Dispose();

			var chrArray = line.ToCharArray();

			double proteinWeightSum = 0.0;
			foreach (var element in chrArray)
			{
				proteinWeightSum = proteinWeightSum + TranslationDictionary.proteinWeight(element);
			}

			Console.WriteLine(proteinWeightSum);
		}
	}
}
